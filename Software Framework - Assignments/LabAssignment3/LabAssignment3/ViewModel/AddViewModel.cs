using LabAssignment3.Message;
using LabAssignment3.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Net.Mail;

namespace LabAssignment3.ViewModel
{
    
    public class AddViewModel:ViewModelBase
    {
        
        private ObservableCollection<Member> ocMembers;
        Member mem;
        MessageMember mmMessage;
        private MemberDB memDB;
        private string ipFName;
        private string ipLName;
        private string ipEMail;
        private int TEXT_LIMIT = 25;
        
        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public AddViewModel()
        {
            mmMessage = new MessageMember();
            mem = new Member(EnteredFName, ipLName, EnteredEmailId);
            ocMembers = new ObservableCollection<Member>();
            memDB = new MemberDB(ocMembers);
            SaveCommand = new RelayCommand<Window>(SaveMethod);
            CancelCommand = new RelayCommand<ICloseable>(CancelMethod);
            memDB.Changed += Event_OnChanged;
        }


        private void CancelMethod(ICloseable window)
        {
            if(window!=null)
            {
                window.Close();
            }
        }
       
        /// <summary>
        /// SaveMethod() which takes an object of Window for saving the new data in the listbox.
        /// </summary>
        /// <param name="window"></param>
        public void SaveMethod(Window window)
        {
            if (window != null)
            {
                if (EnteredFName != null && EnteredLName != null && EnteredEmailId != null)
                {
                    ChangeHandlerEventArgs args = new ChangeHandlerEventArgs();
                    mem = new Member(EnteredFName, EnteredLName, EnteredEmailId);
                    ocMembers.Add(mem);
                    args.MemberList = ocMembers;
                    MemberDB memberdb = new MemberDB(ocMembers);
                    memberdb.OnChanged(args);
                    window.Close();
                }
                else
                {
                    MessageBox.Show("Field cannot be empty");
                }
            }
        }

        /// <summary>
        /// This is an eventhandler Event_OnChanged() to save the data. 
        /// </summary>
        /// <param name="members"></param>
        public void Event_OnChanged(ObservableCollection<Member> members)
        {
            string Fname="", Lname="", Email="";
            foreach (Member m in members)
            {
                Fname = m.Firstname;
                Lname = m.Lastname;
                Email = m.Email;
            }
            mem = new Member(Fname, Lname, Email);
            mmMessage = new MessageMember() { member = mem, MessageType = (int)MessageMember.MessageTypeList.AddList };
            Messenger.Default.Send<MessageMember>(mmMessage);

        }

        public string EnteredFName
        {
            
            get
            {
                return ipFName;
            }
            set
            {
                string input = value.ToString();
                bool rt = Regex.IsMatch(input, "[a-zA-Z]+$");
                try
                {
                    if(value.Length>TEXT_LIMIT)
                    {
                        throw new Exception("Input Character > 25 Characters");
                    }
                    if(!rt)
                    {
                        throw new Exception("Enter Valid Name");
                    }
                    ipFName = value;
                    RaisePropertyChanged("EnteredFName");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Name", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }
        public string EnteredLName
        {
            get
            {
                return ipLName;
            }
            set
            {
                try
                {
                    string input = value.ToString();
                    bool rt = Regex.IsMatch(input, "[a-zA-Z]+$");
                    if (value.Length > 25)
                    {
                        throw new ArgumentException("Input Character > 25 Characters");
                    }
                    if (value.Length == 0)
                    {
                        throw new NullReferenceException("Invalid Entry");
                    }
                    if (!rt)
                    {
                        throw new Exception("Enter Valid Name");
                    }
                    ipLName = value;
                    RaisePropertyChanged("EnteredLName");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Name", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public string EnteredEmailId
        {
            get
            {
                return ipEMail;
            }
            set
            {
                try
                {
                    if (value.Length > TEXT_LIMIT)
                    {
                        throw new ArgumentException("Input Character > 25 Characters");
                    }

                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match m = regex.Match(value);
                    if (m.Success)
                        ipEMail = value;
                    else
                        MessageBox.Show("Please Enter Valid EMail ID!!");
                    RaisePropertyChanged("EnteredEmailId");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Email Id", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

      
    }
}
