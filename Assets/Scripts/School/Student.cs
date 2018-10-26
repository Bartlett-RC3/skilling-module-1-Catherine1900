using System;
namespace RC3Student
{
    public class Student
    {
        public string FirstName;
        private string MiddleName;
        public string LastName;


        private int age;
        private string HomeCountry;


        public Student(string _FirstName, string _MiddleName, string _LastName, int _age, string _HomeCountry)
        {
            FirstName = _FirstName;
            MiddleName = _MiddleName;
            LastName = _LastName;
            age = _age;


        }

        public string getStudentName() {

            return FirstName + LastName;
        }

        public string getStudentCourtry()
        {

            return HomeCountry;
        }

    }
}
