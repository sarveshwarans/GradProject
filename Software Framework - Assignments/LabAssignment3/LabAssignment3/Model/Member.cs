using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabAssignment3.Model
{
   public class Member:ObservableObject
    {
        private ObservableCollection<Member> mList;
        private string fName;
        private string lName;
        private string eMail;
        public int TEXT_LIMIT = 25;
       
        public Member(string fNname, string lName, string eMail)
        {
            this.fName = fNname;
            this.lName = lName;
            this.eMail = eMail;
        }
        public string Firstname
        {
            get
            {
                return fName;
            }
            set
            {
                if(value.Length>TEXT_LIMIT)
                {
                    throw new ArgumentException("Input Character > 25 Characters");
                }
                if(value.Length==0)
                {
                    throw new NullReferenceException("Invalid Entry");
                }
                fName = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lName;
            }
            set
            {
                if(value.Length>TEXT_LIMIT)
                {
                    throw new ArgumentException("Input Character > 25 Characters");
                }
                if(value.Length==0)
                {
                    throw new NullReferenceException("Invalid Entry");
                }
                lName = value;
            }
        }
        public string Email
        {

            get
            {
                return eMail;
            }

            set
            {
                 Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if(value.Length>TEXT_LIMIT)
                {
                    throw new ArgumentException("Input Character > 25 Characters");
                }
                if(value.Length==0)
                {
                    throw new NullReferenceException("Invalid Entry");
                }
                if(value.IndexOf('@')==-1||value.IndexOf('.')==-1)
                {
                    throw new FormatException();
                }
                eMail = value;
            }
        }
        public ObservableCollection<Member> MembersList
        {
            get
            {
                return mList;
            }

            set
            {
                mList = value;
                RaisePropertyChanged("Members");
            }
        }

        /// <summary>
        /// Getter for Display property
        /// </summary>
        public string Display
        {
            get
            {
                return Firstname + " " + Lastname + " " + Email;
            } 
        }
    }
}
