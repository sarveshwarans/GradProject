using LabAssignment3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAssignment3.Message
{
    class MessageMember
    {
        public enum MessageTypeList { UpdateList=0,AddList=1,DeleteList=2};
        public Member member{ get; set; }
        public Member memberN { get; set; }
        public int MessageType;
    }
}
