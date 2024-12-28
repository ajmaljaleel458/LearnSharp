namespace LearnSharp.Collections
{
    using Logger;
    using System;

    public class StudentLog
    {
        private string[] _studentNames;

        private int _numberOfStudents;

        public delegate void StudentIterator(string name);

        public StudentLog(int capacity)
        {
            _studentNames = new string[capacity];

            _numberOfStudents = 0;
        }

        public void Insert(string name)
        {
            _studentNames[_numberOfStudents] = name;
            _numberOfStudents++;
        }

        public void EachStudent(StudentIterator onEachStudent)
        {
            for (int index = 0; index < _numberOfStudents; index++)
                onEachStudent(_studentNames[index]);    
        }
    }

    public class Array
    {   
        public static void SandBox()
        {
            StudentLog studentLog = new StudentLog(5);

            studentLog.Insert("Ajmal");
            studentLog.Insert("Asiya");
            studentLog.Insert("Haris");
            studentLog.Insert("Akumal");

            studentLog.EachStudent((string name) => Logger.Info($"Name : {name}"));
        }
    }
}
