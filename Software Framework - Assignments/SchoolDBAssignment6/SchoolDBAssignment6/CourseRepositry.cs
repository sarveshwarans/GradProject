using SchoolDBAssignment6.Repositry;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBAssignment6
{
   public class CourseRepositry:RepositrySchool<Course>,ICourseRepositry
    {
        public CourseRepositry(DbContext dbcontext):base(SchoolDatabaseEntity.schoolEntity)
        {

        }
        public void Update(Course enity)
        {
            Course course = GetById(enity.CourseId);
            course.CourseName = enity.CourseName;
            course.TeacherId = enity.TeacherId;
            SaveChanges();
        }
    }
}
