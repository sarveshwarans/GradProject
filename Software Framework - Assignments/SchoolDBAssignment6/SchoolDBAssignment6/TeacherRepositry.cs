using SchoolDBAssignment6.Repositry;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBAssignment6
{
    public class TeacherRepositry : RepositrySchool<Teacher>,ITeacherRepositry
    {
        public TeacherRepositry(DbContext dbContext) : base(SchoolDatabaseEntity.schoolEntity)
        {

        }
        public void Update(Teacher entity)
        {
            Teacher teacher = GetById(entity.TeacherId);
            teacher.StandardId = entity.StandardId;
            teacher.TeacherName = entity.TeacherName;
            //teacher.Courses = entity.Courses;
            SaveChanges();
        }

    }
}
