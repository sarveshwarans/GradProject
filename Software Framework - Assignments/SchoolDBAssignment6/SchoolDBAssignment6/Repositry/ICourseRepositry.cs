using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBAssignment6.Repositry
{
    public interface ICourseRepositry:IRepositry<Course>
    {
         void Update(Course entity);
    }
}
