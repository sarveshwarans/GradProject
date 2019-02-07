using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBAssignment6.Repositry
{
   public interface ITeacherRepositry:IRepositry<Teacher>
    {
         void Update(Teacher entity);
    }
}
