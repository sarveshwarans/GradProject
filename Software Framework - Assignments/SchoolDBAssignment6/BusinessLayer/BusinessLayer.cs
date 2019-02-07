using System.Collections.Generic;
using SchoolDBAssignment6.Repositry;
using SchoolDBAssignment6;
using System.Linq;

namespace BusinessLayer
{
    public class BusinessLayer:IBusinessLayer
    {
        private readonly IStandardRepositry _standardRepositry;
        private readonly ITeacherRepositry _teacherRepositry;
        private readonly ICourseRepositry _courseRepositry;
        public BusinessLayer()
        {
            _standardRepositry = new StandardRepositry(new SchoolDBEntities());
            _teacherRepositry = new TeacherRepositry(new SchoolDBEntities());
            _courseRepositry = new CourseRepositry(new SchoolDBEntities());
        }


        public IList<Standard> GetAllStandards()
        {
            return _standardRepositry.GetAll().ToList();

        }
        public Standard GetStandardById(int id)
        {
            //return _standardRepositry.GetById(id);
            return _standardRepositry.GetById(id);
        }
        public Standard GetStandardByName(string name)
        {
            IQueryable<Standard> stanQ = _standardRepositry.SearchFor((stan) => stan.StandardName.Equals(name));
            return stanQ.Single();
        }

        public Standard GetTeacherByStandard(int id)
        {
            return _standardRepositry.GetSingle(s => s.StandardId == id, s => s.Teachers);
        }
        public void AddStandard(Standard standard)
        {
            _standardRepositry.Insert(standard);
        }

        public void UpdateStandard(Standard standard)
        {
            _standardRepositry.Update(standard);
        }

        public void RemoveStandard(Standard standard)
        {
            _standardRepositry.Delete(standard);
        }

        public IList<Teacher> GetAllTeachers()
        {
            return _teacherRepositry.GetAll().ToList();
        }
        public Teacher GetTeacherById(int id)
        {
            return _teacherRepositry.GetById(id);
        }

        public Teacher GetCourseByTeacher(int id)
        {
            return _teacherRepositry.GetSingle(s => s.TeacherId == id, s => s.Courses);
        }
        public Teacher GetTeacherByName(string name)
        {
            IQueryable<Teacher> teaQ = _teacherRepositry.SearchFor(teach => (teach.TeacherName.Equals(name)));
            return teaQ.Single();
        }
        public void AddTeacher(Teacher teacher)
        {
            _teacherRepositry.Insert(teacher);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepositry.Update(teacher);
        }
        public void RemoveTeacher(Teacher teacher)
        {
            _teacherRepositry.Delete(teacher);
        }

        public IList<Course> GetAllCourse()
        {
            return _courseRepositry.GetAll().ToList();
        }
        public Course GetCourseById(int id)
        {
            return _courseRepositry.GetSingle(s => s.CourseId == id);
        }
        public Course GetCourseByName(string name)
        {
            IQueryable<Course> teaQ = _courseRepositry.SearchFor(cour => (cour.CourseName.Equals(name)));
            return teaQ.Single();
        }
        public void AddCourse(Course course)
        {
            _courseRepositry.Insert(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepositry.Update(course);
        }
        public void RemoveCourse(Course course)
        {
            _courseRepositry.Delete(course);
        }
    }
}
