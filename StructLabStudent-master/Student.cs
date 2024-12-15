using System;
using System.Text;
using System.Linq;

namespace struct_lab_student
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;

        public Student(string lineWithAllData)
        {
            //new[] { ' ', '\t' }просто масив табуляції, можна записати окремим рядком
            string[] data = lineWithAllData.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            surName = data[0];
            firstName = data[1];
            patronymic = data[2];
            //другі скобки відповідають за те щоб читався тільки нульовий символ
            sex = char.ToUpper(data[3][0]);
            dateOfBirth = data[4];
            mathematicsMark = data[5][0];
            physicsMark = data[6][0];
            informaticsMark = data[7][0];
            scholarship = int.Parse(data[8]);
        }
    }
}
