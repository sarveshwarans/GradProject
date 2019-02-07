using LabAssignment3.Model;
using LabAssignment3.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using LabAssignment3.Message;
using System.Windows.Controls;

namespace LabAssignment3.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Member> ocMembers;
        private MemberDB memDB;
        private Member currMember;

        public MainViewModel()
        {
            ocMembers = new ObservableCollection<Member>();
            memDB = new MemberDB(Members);
            AddCommand = new RelayCommand(AddMethod);
            ExitCommand = new RelayCommand<ICloseable>(this.ExitMethod);
            DeleteCommand = new RelayCommand(DeleteMethod);
            SelectedItemCommand = new RelayCommand(SelectItemMethod);
            SelectMethod();
            Messenger.Default.Register<MessageMember>(this, OnMessageReceived);
        }

        public Member CurrentMember
        {
            get
            {
                return currMember;
            }
            set
            {
                currMember = value;
                RaisePropertyChanged("CurrentMember");
            }
        }
        /// <summary>
        /// OnMessageReceived Method when receives the MessageMember obj as parameter and then on processing calls the 
        /// SaveMethod() method.
        /// </summary>
        /// <param name="obj"></param>
       private void OnMessageReceived(MessageMember obj)
        {
           
            if (obj.MessageType == ((int)MessageMember.MessageTypeList.AddList))
            {
                memDB += obj.member;
            }
            else if (obj.MessageType == ((int)MessageMember.MessageTypeList.UpdateList))
            {
                if (Members.Contains(obj.memberN))
                {
                    int indexOfMember = Members.IndexOf(obj.memberN);
                    Members.Remove(obj.memberN);
                    Members.Insert(indexOfMember, obj.member);
                }
            }
            else if (obj.MessageType == ((int)MessageMember.MessageTypeList.DeleteList))
            {
                memDB -= obj.memberN;
            }
            SaveMethod();
        }
    
        private void SelectItemMethod()
        {
            ChangeMember cmWindow = new ChangeMember(currMember);
            cmWindow.Show();
        }

        public void SelectMethod()
        {
            Members = memDB.GetMembership();
        }

        public ObservableCollection<Member> Members
        {
            get
            {
                return ocMembers;
            }
            set
            {
                ocMembers = value;
                RaisePropertyChanged("Members");
            }
        }
        private void DeleteMethod()
        {
            MessageMember mmMessage = new MessageMember();
            mmMessage.memberN = CurrentMember;
            mmMessage.MessageType = (int)MessageMember.MessageTypeList.DeleteList;
            Messenger.Default.Send<MessageMember>(mmMessage);
        }

        private void ExitMethod(ICloseable window)
        {
            if(window!=null)
            {
                window.Close();
            }
        }
        public ICommand SelectedItemCommand
        {
            get;
            private set;
        }
        public ICommand AddCommand
        {
            get;
            private set;
        }
        public ICommand ExitCommand
        {
            get;
            private set;
        }
        public ICommand DeleteCommand
        {
            get;
            private set;
        }
        /// <summary>
        /// This method will show a new window for adding new data.
        /// </summary>
        public void AddMethod()
        {         
            AddMember amAdd = new AddMember();
            amAdd.Show();  
        }
        public void SaveMethod()
        {
            memDB.SaveMembership(Members);
        }

    }

}