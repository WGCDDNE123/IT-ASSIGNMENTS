using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
     internal class Program
     {
          static void Main(string[] args)
          {
               Console.WriteLine("Enter student Name");
               string studentName = Console.ReadLine();

               Console.WriteLine("Enter Matric No.");
               string matricNo = Console.ReadLine();

               Console.WriteLine("Enter Semester");
               string semester = Console.ReadLine();

               Console.WriteLine("Enter level");
               string level = Console.ReadLine();

            


               int totalWeightedScore = 0;
               int totalUnit = 0, studGPA = 0;
               string space = "TOTAL UNIT IS:";
               string space2 = "";
               Console.WriteLine("\n\nEnter Number of courses");
               int courseNo = Convert.ToInt32(Console.ReadLine());

               string[] courseCode = new string[courseNo];
               string[] gradeScore = new string[courseNo];
               int[] courseUnit = new int[courseNo];
               int[] weightedScore = new int[courseNo];

               for (int i = 0; i < courseNo; i++)
               {
                    Console.WriteLine("Enter course code");
                    courseCode[i] = Console.ReadLine();

                    Console.WriteLine("Enter Course Unit");
                    courseUnit[i] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter grade");
                    gradeScore[i] = Console.ReadLine();
               }
               
           
               for (int i = 0; i < courseUnit.Length; i++)
               {
                    if (gradeScore[i] == "A")
                    {
                         weightedScore[i] = courseUnit[i] * 5;
                         
                    }


                    else if (gradeScore[i] == "B")
                    {
                         weightedScore[i] = courseUnit[i] * 4;
                    }


                    else if (gradeScore[i] == "C")
                    {
                         weightedScore[i] = courseUnit[i] * 3;
                    }

                    else if (gradeScore[i] == "D")
                    {
                         weightedScore[i] = courseUnit[i] * 2;
                    }
                    else if (gradeScore[i] == "F")
                    {
                         weightedScore[i] = courseUnit[i] * 0;
                    }
                    totalWeightedScore += weightedScore[i];
               }

                
               Console.WriteLine("{0,-50} {1, -50}", "\nNAME: " + studentName, "MATRIC NO: " + matricNo);
               Console.WriteLine("{0,-50} {1, -50}", "\nSEMESTER: " + semester, "LEVEL: " + level);
               Console.WriteLine("\n\n");
               Console.WriteLine("{0,-30}|{1, -30}|{2,-30}|{3,-30}", "COURSECODE", "UNITS", "GRADE", "WEIGHTEDSCORE");
               for (int j = 0; j < courseCode.Length; j++)
               {
                    totalUnit += courseUnit[j];
                    Console.WriteLine("{0,-30}|{1, -30}|{2,-30}|{3,-30}", courseCode[j], courseUnit[j], gradeScore[j], weightedScore[j]);
               }
                  studGPA = totalWeightedScore / totalUnit;

               Console.WriteLine("{0,-30}|{1, -30} {2,-30}|{3,-30}", space, totalUnit, space2, totalWeightedScore);
               Console.WriteLine("YOUR GPA IS:" + studGPA + "/5.0");
          }
          
          
         
     }

        

        
}

