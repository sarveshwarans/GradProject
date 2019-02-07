using SchoolDBAssignment6.Repositry;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBAssignment6
{
    public class StandardRepositry :RepositrySchool<Standard>,IStandardRepositry
    {
       
        public StandardRepositry(DbContext dbcontext):base(SchoolDatabaseEntity.schoolEntity)
        {

        }
        public void Update(Standard entity)
        {
            Standard standard = GetById(entity.StandardId);
            standard.Description = entity.Description;
            standard.StandardName = entity.StandardName;
            standard.Students = entity.Students;
            standard.Teachers = entity.Teachers;
            base.SaveChanges();
        }
    }
}
