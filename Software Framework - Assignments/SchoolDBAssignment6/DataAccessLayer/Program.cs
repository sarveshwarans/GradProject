using BusinessLayer;
using SchoolDBAssignment6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        BusinessLayer.BusinessLayer layer;

        public Program()
        {
            layer = new BusinessLayer.BusinessLayer();
        }
        static void Main(string[] args)
        {
            Program client = new Program();
            client.CRUDOperations();
        }

        private void CRUDOperations()
        {
            string option;
            string standardId;
            do
            {
                OperationList();
                option = Console.ReadLine();
                Console.Write("\n");
                switch(option)
                {
                    case "1":
                        Console.WriteLine("Enter Standard Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Description");
                        string description = Console.ReadLine();
                        Standard standard = new Standard()
                        {
                            StandardName = name,
                            Description=description
                        };
                        layer.AddStandard(standard);
                        Console.WriteLine("Standard Added");
                        break;
                    case "2":
                        Console.WriteLine("Enter the Standard Id to Delete");
                        standardId = Console.ReadLine();
                        Standard stanDel = layer.GetStandardById(Convert.ToInt32(standardId));
                        layer.RemoveStandard(stanDel);
                        Console.WriteLine("Standard Deleted!");
                        break;
                    case "3":
                        Console.WriteLine("Enter Standard Id to Update");
                        Standard stanid = SearchStandardByOption(option);
                        if (stanid == null)
                        {
                            break;
                        }
                        Console.WriteLine("Enter New Standard Name");
                        string snName = Console.ReadLine();
                        Console.WriteLine("Enter New Description");
                        string snDescription = Console.ReadLine();
                        stanid.StandardName = snName;
                        stanid.Description = snDescription;
                        layer.UpdateStandard(stanid);
                        Console.WriteLine("Standard Updated!");
                        break;
                    case "4":
                        Console.WriteLine("\t 1. Search By Id \t 2. Search By Name");
                        string input = Console.ReadLine();
                        Console.WriteLine("Enter the data to Search");
                        SearchStandardByOption(input);
                        break;
                    case "5":
                        Console.WriteLine("Enter the Standard ID");
                        //standardId = Console.ReadLine();
                        
                        Standard stand=SearchTeacherByStandard(option);
                        if(stand!=null && stand.Teachers.Count>0)
                        {
                            Console.WriteLine("Teacher ID\t Teacher Name\tStandard ID");
                            foreach(Teacher t in stand.Teachers)
                            {
                                Console.WriteLine("{0}\t{1}",t.TeacherId.ToString().PadRight(10), t.TeacherName.PadRight(10));

                            }
                        }
                        else
                        {
                            Console.WriteLine("No Students are related to this standard");
                        }
                        break;
                    case "6":
                        List<Standard> list54 = (List<Standard>)layer.GetAllStandards();
                        if (list54 != null && list54.Count > 0)
                        {
                            Console.WriteLine("Standard ID\tStandard Name");
                            foreach (Standard stan in list54)
                            {
                                Console.WriteLine("{0}\t{1}", stan.StandardId.ToString().PadRight(11), stan.StandardName);
                            }
                        }
                        break;
                    case "7":
                        Console.WriteLine("Enter the teacher details");
                        Console.WriteLine("Enter Standard Id");
                        standardId = Console.ReadLine();
                        Console.WriteLine("Enter Teacher Name");
                        string teacherName = Console.ReadLine();
                        Teacher teach = new Teacher();
                        {
                            teach.StandardId = Convert.ToInt32(standardId);
                            teach.TeacherName = teacherName;
                        }
                        layer.AddTeacher(teach);
                        Console.WriteLine("Teacher Created");
                        break;
                    case "8":
                        Console.WriteLine("Enter Teacher Id to Update");
                        Teacher t1 = SearchTeacherByOptions(option);
                        if(t1==null)
                        {
                            break;
                        }
                        Console.WriteLine("Enter Teacher Name");
                        string tname = Console.ReadLine();
                        Console.WriteLine("Enter Standard Id");
                        standardId = Console.ReadLine();
                        t1.TeacherName = tname;
                        t1.StandardId = Int32.Parse(standardId);
                        layer.UpdateTeacher(t1);
                        break;
                    case "9":
                        Console.WriteLine("Enter Teacher Id to delete");
                        standardId = Console.ReadLine();
                        Teacher t2 = layer.GetTeacherById(Int32.Parse(standardId));
                        layer.RemoveTeacher(t2);
                        Console.WriteLine("Teacher Deleted");
                        break;
                    case "10":
                        Console.WriteLine("\t1. Search by ID\n\t2. Search by name");
                        string line58 = Console.ReadLine();
                        Console.WriteLine("Enter the data to search:");
                        //List<string> dataList58 = Tokenize(line58);
                        //standardId = Console.ReadLine();
                        SearchTeacherByOptions(line58);
                        break;
                    case "11":
                        List<Teacher> list = (List<Teacher>)layer.GetAllTeachers();
                        Console.WriteLine(list.Count);
                        if (list != null && list.Count > 0)
                        {
                            Console.WriteLine("Teacher ID \tTeacher Name\t Standard Id \t Course ID\tCourse Name");
                            foreach (Teacher t3 in list)
                            {
                               
                                Console.WriteLine(PrintTeacherDetails(t3));
                            }
                        }
                        break;
                    case "12":
                        Console.WriteLine("Enter the Course details");
                        Console.WriteLine("Enter Teacher Id");
                        standardId = Console.ReadLine();
                        Console.WriteLine("Enter Course Name");
                        string CourseName = Console.ReadLine();
                        Course course = new Course();
                        {
                            course.TeacherId = Convert.ToInt32(standardId);
                            course.CourseName = CourseName;
                        }
                        layer.AddCourse(course);
                        Console.WriteLine("Course Created");
                        break;
                    case "13":
                        Console.WriteLine("Enter Course Id to Update");
                        Course c1 = SearchCourseByOptions(option);
                        if (c1 == null)
                        {
                            break;
                        }
                        Console.WriteLine("Enter Course Name");
                        string cname = Console.ReadLine();
                        Console.WriteLine("Enter Teacher Id");
                        standardId = Console.ReadLine();
                        c1.CourseName = cname;
                        c1.TeacherId = Int32.Parse(standardId);
                        layer.UpdateCourse(c1);
                        break;
                    case "14":
                        Console.WriteLine("Enter Course Id to delete");
                        standardId = Console.ReadLine();
                        Course c2 = layer.GetCourseById(Int32.Parse(standardId));
                        layer.RemoveCourse(c2);
                        Console.WriteLine("Course Deleted");
                        break;
                    case "15":
                        Console.WriteLine("\t1. Search by ID\n\t2. Search by name");
                        string line = Console.ReadLine();
                        Console.WriteLine("Enter the data to search:");
                        SearchCourseByOptions(line);
                        break;
                    case "16":
                        List<Course> courselist = (List<Course>)layer.GetAllCourse();
                        if (courselist != null && courselist.Count > 0)
                        {
                            Console.WriteLine("Course ID\tCourse Name");
                            foreach (Course cou in courselist)
                            {
                                Console.WriteLine("{0}\t{1}", cou.CourseId.ToString().PadRight(11), cou.CourseName);
                            }
                        }
                        break;
                    case "17":
                        Console.WriteLine("Enter the Teacher ID");
                        //standardId = Console.ReadLine();
                        Teacher teach1 = SearchCourseByTeacher(option);
                        if (teach1 != null && teach1.Courses.Count > 0)
                        {
                            Console.WriteLine("Teacher ID\t Course ID\tCourse Name");
                            foreach (Course t in teach1.Courses)
                            {
                                Console.WriteLine("{0}\t{1}\t{2}", t.TeacherId.ToString().PadRight(10),t.CourseId.ToString().PadRight(10), t.CourseName.PadRight(10));

                            }
                        }
                        else
                        {
                            Console.WriteLine("No Course are related to this Teacher");
                        }
                        break;
                    case "18":
                        break;


                }
            }
            while (!option.Equals("18"));
        }

        private Course SearchCourseByOptions(string option)
        {
            Course course;
            string input = Console.ReadLine();
            if(option.Equals("2"))
            {
                try
                {
                    course = layer.GetCourseByName(input);
                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("No such record found");
                    return null;
                }
            }
            else
            {
                course = layer.GetCourseById(Int32.Parse(input));
            }
            if(course==null)
            {
                Console.WriteLine("No such record found");
                return null;
            }
            Console.WriteLine("The record found is:");
            Console.WriteLine("Course ID\tCourse Name");
            Console.WriteLine("{0}\t{1}", course.CourseId.ToString().PadRight(11),
                course.CourseName.PadRight(13));
            return course;
        }

        private Standard SearchTeacherByStandard(string option)
        {
            Standard stan;
            //List<string> idList = Tokenize(Console.ReadLine());
            string input = Console.ReadLine();
            //if (option.Equals("2"))
            //{

            //    try
            //    {
            //        stan = layer.GetStandardByName(input);
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        Console.WriteLine("No such record found!");
            //        return null;
            //    }
            //}
            //else
            //{
            //    stan = layer.GetStandardById(Int32.Parse(input));
            //}
            try
            {
                stan = layer.GetTeacherByStandard(Int32.Parse(input));
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("No Such record Found!");
                return null;
            }
            
            if (stan == null)
            {
                Console.WriteLine("No such record found!");
                return null;
            }
            Console.WriteLine("The record found is:");
            Console.WriteLine("Standard ID\tStandard Name\tDescription");
            Console.WriteLine("{0}\t{1}\t{2}", stan.StandardId.ToString().PadRight(11),
                stan.StandardName.PadRight(13), stan.Description);
            return stan;
        }

        private Teacher SearchCourseByTeacher(string option)
        {
            Teacher stan;
            //List<string> idList = Tokenize(Console.ReadLine());
            string input = Console.ReadLine();
            try
            {
                stan = layer.GetCourseByTeacher(Int32.Parse(input));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No Such record Found!");
                return null;
            }

            if (stan == null)
            {
                Console.WriteLine("No such record found!");
                return null;
            }
            Console.WriteLine("The record found is:");
            Console.WriteLine("Standard ID\tStandard Name\tDescription");
            Console.WriteLine("{0}\t{1}", stan.TeacherId.ToString().PadRight(11),
                stan.TeacherName.PadRight(13));
            return stan;
        }

        private Standard SearchStandardByOption(string option)
        {
            Standard stan;
            //List<string> idList = Tokenize(Console.ReadLine());
            string input = Console.ReadLine();
            if (option.Equals("2"))
            {

                try
                {
                    stan = layer.GetStandardByName(input);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No such record found!");
                    return null;
                }
            }
            else
            {
                stan = layer.GetStandardById(Int32.Parse(input));
            }
            if (stan == null)
            {
                Console.WriteLine("No such record found!");
                return null;
            }
            Console.WriteLine("The record found is:");
            Console.WriteLine("Standard ID\tStandard Name\tDescription");
            Console.WriteLine("{0}\t{1}\t{2}", stan.StandardId.ToString().PadRight(11),
                stan.StandardName.PadRight(13), stan.Description);
            return stan;
        }

        private Teacher SearchTeacherByOptions(string option)
        {
            Teacher teach;
            string input = Console.ReadLine();
            if(option.Equals("2"))
            {
                try
                {
                    teach = layer.GetTeacherByName(input);

                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("No Such Record Found");
                    return null;
                }
            }
            else
            {
                teach = layer.GetTeacherById(Convert.ToInt16(input));
            }
            if(teach==null)
            {
                Console.WriteLine("No Such Record Found");
                return null;
            }
            Console.WriteLine("The record found is:");
           Console.WriteLine("Teacher Id\tTeacher Name");
            Console.WriteLine("{0}\t{1}", teach.TeacherId.ToString().PadRight(11),
                teach.TeacherName.PadRight(13));
            //Console.WriteLine(PrintTeacherDetails(teach));
            return teach;
        }

        private string PrintTeacherDetails(Teacher teach)
        {
            StringBuilder builder = new StringBuilder();
            int id=0;
            string name=" ";
            builder.Append(teach.TeacherId.ToString().PadRight(15));
            builder.Append(" ");
            builder.Append(teach.TeacherName.PadRight(20));
            if(teach.StandardId!=null)
            {
                builder.Append(teach.StandardId.ToString().PadRight(20));
            }
            if(teach.Courses!=null)
            {
                foreach(var c in teach.Courses)
                {
                    id = c.CourseId;
                    name = c.CourseName;
                }
                builder.Append(id.ToString().PadRight(10));
                builder.Append(" ");
                builder.Append(name.PadRight(10));
            }
            else
            {
                builder.Append("Null".PadLeft(10));
            }
            return builder.ToString();
        }

        private void OperationList()
        {
            Console.WriteLine("CRUD OPERATION:");
            Console.WriteLine("1. Add new Standard.");
            Console.WriteLine("2. Delete Standard");
            Console.WriteLine("3. Update a Standard.");
            Console.WriteLine("4. Search a Standard.");
            Console.WriteLine("5. Display Teachers related to Standard.");
            Console.WriteLine("6. Display all Standard.");
            Console.WriteLine("7. Add new Teacher.");
            Console.WriteLine("8. Update Teacher.");
            Console.WriteLine("9. Delete Teacher.");
            Console.WriteLine("10. Search Teacher.");
            Console.WriteLine("11. Display All Teacher.");
            Console.WriteLine("12. Add new Course.");
            Console.WriteLine("13. Update Course");
            Console.WriteLine("14. Delete Course");
            Console.WriteLine("15. Search Course");
            Console.WriteLine("16. Display All Course");
            Console.WriteLine("17. Display Courses related to Teacher.");
            Console.WriteLine("18. Exit");
        }
    }
}
