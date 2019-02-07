using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using LabAssignment3.ViewModel;

namespace LabAssignment3.Model
{
    
    public class MemberDB: ObservableObject
    {
        
        private MemberIndexer MemberIndexer = new MemberIndexer(); 
        public MemberDB(ObservableCollection<Member> m)
        {
            MemberIndexer.ocMembers = m;
        }

        /// <summary>
        /// GetMembership() to retrieve the data from the file.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Member> GetMembership()
        {
            string strRow = "";
            string[] strCol;
            try
            {
                if (File.Exists(@"file.txt"))
               {
                    StreamReader srInput = new StreamReader(new FileStream(@"file.txt",FileMode.OpenOrCreate,FileAccess.Read),false);
                    while(srInput.Peek()!=-1)
                    {
                        strRow = srInput.ReadLine();
                        strCol = strRow.Split('-');
                        Member m = new Member(strCol[0], strCol[1], strCol[2]);
                        Members.Add(m);

                    }
                    srInput.Close();
                    
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid e-mail address format");
            }
            return MemberIndexer.ocMembers;
        }

        /// <summary>
        /// SaveMembership method for saving it to the test file.
        /// </summary>
        /// <param name="memberdata"></param>
        public void SaveMembership(ObservableCollection<Member> memberdata)
        {
            using (StreamWriter swWriter = new StreamWriter(@"file.txt", false))
            {
                foreach (Member m in memberdata)
                {
                    swWriter.Write(m.Firstname+"-");
                    swWriter.Write(m.Lastname+"-");
                    swWriter.Write(m.Email);
                    swWriter.WriteLine();
                    
                }
                swWriter.Close();
            }
            
        }
        /// <summary>
        /// Overloaded operator + 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MemberDB operator +(MemberDB m1, Member m)
        {
            m1.Add(m);
            return m1;
        }
        public void Add(Member m) => MemberIndexer.ocMembers.Add(m);
        public void Remove(Member m) => MemberIndexer.ocMembers.Remove(m);
        /// <summary>
        /// Overloaded operator -
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static MemberDB operator -(MemberDB m1, Member m)
        {
            m1.Remove(m);
            return m1;
        }
        
        public ObservableCollection<Member> Members
        {
            get
            {
                return MemberIndexer.ocMembers;
            }
            set
            {
                MemberIndexer.ocMembers = value;
                RaisePropertyChanged("Member");
            }
        }
        public void OnChanged(ChangeHandlerEventArgs e)
        {
            AddViewModel avModel = new AddViewModel();
            Changed = new Action<ObservableCollection<Member>>(avModel.Event_OnChanged);
            Changed.Invoke(e.MemberList);
        }
        public Action<ObservableCollection<Member>> Changed;
    }

    class MemberIndexer
    {
        public ObservableCollection<Member> ocMembers;
        /// <summary>
        /// Indexer 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Member this[int i]
        {
            get
            {
                return ocMembers[i];
            }
            set
            {
                ocMembers[i] = value;
            }
        }

    }

   public class ChangeHandlerEventArgs:EventArgs
    {
        public ObservableCollection<Member> MemberList { get; set; }
    }
}
