using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task2
{
    public partial class Student
    {
        private int id;
        private string name;
        private string surname;
        private DateTime dateOfBirth;
        private int age;
        private bool isFulltime;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int Age { get => age; set => age = value; }
        public bool IsFulltime { get => isFulltime; set => isFulltime = value; }

        public Student()
        {

        }

        public Student(int id, string name, string surname, DateTime dob, int age, bool fullTime)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dob;
            this.IsFulltime = fullTime;
        }
    }
}