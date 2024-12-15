using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        // You may (if want) change ``Student[]'' to ``List<Student>''
        {
            
            Student[] students = File.ReadAllLines(fileName)             //масив з рядків файла
                                                                         //цикл не треба. методи LINQ обробляють одразу всі рядки.
                   .Where(line => !string.IsNullOrWhiteSpace(line))      //викидає пусті рядки
                   //.Select(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)) //рядки роділяються за табуляціям
                   ////далі масиви що утоврились з рядків призначаються об'єктами в струк.
                   //.Select(data => new Student
                   //{
                   //    surName = data[0],
                   //    firstName = data[1],
                   //    patronymic = data[2],
                   //    sex = char.ToUpper(data[3][0]),
                   //    dateOfBirth = data[4],
                   //    mathematicsMark = data[5][0],
                   //    physicsMark = data[6][0],
                   //    informaticsMark = data[7][0],
                   //    scholarship = int.Parse(data[8])
                   //})
                   .Select(line => new Student(line))
                   .ToArray();

            return students;
        }

        static void RunMenu(Student[] studs)
        // You may (if want) change ``Student[]'' to ``List<Student>''
        {
            
            Var21(studs);
        }
        static void Var21(Student[] studs)
        {
            Console.WriteLine("Студенти з середніми балами вище 4.5:");
            foreach (var student in studs)
            {
                double average = CalculateAverage(student);
                if (average > 4.5)
                {
                    Console.WriteLine($"{student.surName} {student.firstName} {student.patronymic}, середній бал: {average:F2}");
                    //f2 -- floating point з двома знаками після коми
                }

            }
            Console.ReadKey();
        }

        static double CalculateAverage(Student student)
        {
            int totalMarks = 0;
            int totalSubjects = 0;

            if (student.mathematicsMark != '-')
            {
                totalMarks += int.Parse(student.mathematicsMark.ToString());
                totalSubjects++;
            }
            else
            {
                //якщо оцінка "-" - додаємо 2 бали
                totalMarks += 2;
                totalSubjects++;
            }

            if (student.physicsMark != '-')
            {
                totalMarks += int.Parse(student.physicsMark.ToString());
                totalSubjects++;
            }
            else
            {
                totalMarks += 2;
                totalSubjects++;
            }

            if (student.informaticsMark != '-')
            {
                totalMarks += int.Parse(student.informaticsMark.ToString());
                totalSubjects++;
            }
            else
            {
                totalMarks += 2;
                totalSubjects++;
            }

            return (double)totalMarks / totalSubjects;
        }

        static void Main(string[] args)
        {
            Student[] studs = ReadData("input.txt");
            RunMenu(studs);
        }
    }
}
