using SchoolDBAssignment6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusinessLayer
    {
        IList<Standard> GetAllStandards();
        Standard GetStandardById(int id);
        Standard GetStandardByName(string name);

        Standard GetTeacherByStandard(int id);

        Teacher GetCourseByTeacher(int id);
        void AddStandard(Standard standard);
        void UpdateStandard(Standard standard);
        void RemoveStandard(Standard standard);

        IList<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int id);
        Teacher GetTeacherByName(string name);
        void AddTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teaccher);
        void RemoveTeacher(Teacher teacher);

        IList<Course> GetAllCourse();
        Course GetCourseById(int id);
        Course GetCourseByName(string name);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void RemoveCourse(Course course);
    }
}
