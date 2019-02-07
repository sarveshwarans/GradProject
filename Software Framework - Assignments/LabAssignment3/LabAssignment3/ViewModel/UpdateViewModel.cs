using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabAssignment3.Message;
using LabAssignment3.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace LabAssignment3.ViewModel
{

    public class UpdateViewModel : ViewModelBase
    {
        private string ipFName;
        private string ipLName;
        private string ipEmail;
        private Member currMethod;
        private int TEXT_LIMIT=25;

        public ICommand UpdateCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public UpdateViewModel()
        {
            UpdateCommand = new RelayCommand<ICloseable>(UpdateMethod);
            CancelCommand = new RelayCommand<ICloseable>(CancelMethod);
        }

        private void CancelMethod(ICloseable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        internal void SetProperties(Member m)
        {
            currMethod = m;
            EnteredFname = m.Firstname;
            EnteredLname = m.Lastname;
            EnteredemailId = m.Email;
        }

        internal void SetProperties(ListBox lb)
        {
            int i = lb.SelectedIndex;
        }

        /// <summary>
        /// UpdateMethod () which take IClosable object as an input. 
        /// It makes sure that the fields are no empty.
        /// If the fields have valid data, then it updates it.
        /// </summary>
        /// <param name="window"></param>
        private void UpdateMethod(ICloseable window)
        {
            if (EnteredFname == null || EnteredLname == null || EnteredemailId == null)
            {
                MessageBox.Show("Fields cannot be empty");
            }
            else
            {
                
                MessageMember mmMessage = new MessageMember();
                mmMessage.memberN = CurrentMember;
                mmMessage.member = new Member(EnteredFname, EnteredLname, EnteredemailId);
                mmMessage.MessageType = (int)MessageMember.MessageTypeList.UpdateList;
                Messenger.Default.Send<MessageMember>(mmMessage);
                window.Close();
            }
        }

        public string EnteredFname
        {
            get
            {
                return ipFName;
            }
            set
            {
                try
                {
                    string strInput = value.ToString();
                    bool rt = Regex.IsMatch(strInput, "[a-zA-Z]+$");
                    if (value.Length > TEXT_LIMIT)
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
                    ipFName = value;
                    RaisePropertyChanged("EnteredFname");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid First Name", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public string EnteredLname
        {
            get
            {
                return ipLName;
            }
            set
            {
                try
                {
                    string strInput = value.ToString();
                    bool rt = Regex.IsMatch(strInput, "[a-zA-Z]+$");
                    if (value.Length > TEXT_LIMIT)
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
                    RaisePropertyChanged("EnteredLname");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Last Name", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        public string EnteredemailId
        {
            get
            {
                return ipEmail;
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
                        ipEmail = value;
                    else
                        MessageBox.Show("Please Enter Valid EMail ID!!");
                    RaisePropertyChanged("EnteredemailId");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Enter Valid Email Id", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// This is a getter and setter for CurrentMemeber property
        /// </summary>
        public Member CurrentMember
        {
            get
            {
                return currMethod;
            }
            set
            {
                currMethod = value;
            }
        }
    }
}
