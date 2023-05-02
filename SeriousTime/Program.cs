using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using SeriousTime;



namespace SeriousTime
{
     public class StudIds // base class (parent) 
     {
          public string Name { get; set; }
          public string Id { get; set; }
          public string Level { get; set; }
          public decimal StudGpa { get; set; }
          public override string ToString()
          {
               return $"$NAME: {Name}\nSTUDENT ID: {Id}\nLevel: {Level}";
          }
     }


     public class CourseStuff
     {
          public string CourseCode { get; set; }
          public int CourseUnit { get; set; }
          public string GradeScore { get; set; }
          public int CourseNo { get; set; }
          public decimal Total { get; set; }
          public decimal TotalUnit { get; set; }
          public decimal WeightedScore { get; set; }

          //before I was battling with array because the foreach loop would reach to the end of it, so Instead
          //I used a list
     }


     public class Program : CourseStuff
     {

          public static Dictionary<string, int> Grades = new Dictionary<string, int>(100)
          {
               { "A", 5 },
               { "B", 4 },
               { "C", 3 },
               { "D", 2 },
               { "F", 0 }
          };

          public static void Main(string[] args)
          {
               
               var displayTotal = "TOTAL ============";
               var student = new StudIds()
               {
                    Name = Console.ReadLine(),
                    Id = Console.ReadLine(),
                    Level = Console.ReadLine(),
                    StudGpa = 0.00m
               };

               var thanks = new CourseStuff();
               
               Console.WriteLine("Enter number of courses");
              thanks.CourseNo = Convert.ToInt32(Console.ReadLine());

              //making an object of CourseStuff Class that is a List....
              //List was better used because it is resizes itself as needed.
              var courseList = new List<CourseStuff>();

               for (int i = 0; i < thanks.CourseNo; i++)
               {
                    CourseStuff course = new CourseStuff();
                    Console.WriteLine("Enter CourseCode");
                    course.CourseCode = Console.ReadLine();

                    Console.WriteLine("Enter Course Unit: ");
                    course.CourseUnit = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("GRADE: ");
                    course.GradeScore = Console.ReadLine();

                    courseList.Add(course);
               }
               

               foreach (CourseStuff d in courseList)
               {
                    d.WeightedScore = Grades[d.GradeScore] * d.CourseUnit;
                    //making WeightedScore more visible (scope)
                    thanks.WeightedScore = d.WeightedScore;
                   thanks.Total += d.WeightedScore;

               }

               Console.WriteLine(student);
               Console.WriteLine("\n{0, -30}|{1,-30}|{2,-30}|{3,-30}", "COURSES", "UNITS", "GRADES", "WEIGHTED");

               foreach (CourseStuff c in courseList)
               {
                    thanks.TotalUnit += c.CourseUnit;
                    thanks.WeightedScore = c.WeightedScore;
                    Console.WriteLine("{0,-30}|{1,-30}|{2,-30}|{3,-30}", c.CourseCode, c.CourseUnit, c.GradeScore, c.WeightedScore);
               }

               //Console.WriteLine(thanks.TotalUnit);
               student.StudGpa = thanks.Total / thanks.TotalUnit;

               Console.WriteLine("\n{0, -30}|{1,-30}|{2,-30}|{3,-30}", displayTotal, thanks.TotalUnit, "", thanks.Total);
               Console.WriteLine("\nSTUDENT GPA: " + student.StudGpa.ToString("F2"));
               Console.ReadLine();


          }
     }

    
}










