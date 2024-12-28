namespace LearnSharp.Collections
{
    using Logger;
    using System;
    using static global::LearnSharp.Collections.StudentLog;

    public class StudentLog
    {
        private string[] _studentNames;

        private float[] _studentExamScores;

        private int _numberOfStudents;

        public delegate void StudentIterator(string name, float score);

        public StudentLog(int capacity)
        {
            _studentNames = new string[capacity];

            _studentExamScores = new float[capacity];

            _numberOfStudents = 0;
        }

        public void Insert(string name, float score)
        {
            _studentNames[_numberOfStudents] = name;
            _studentExamScores[_numberOfStudents] = score;
            _numberOfStudents++;
        }

        public void EachStudent(StudentIterator onEachStudent)
        {
            for (int index = 0; index < _numberOfStudents; index++)
                onEachStudent(_studentNames[index], _studentExamScores[index]);    
        }

        public float GetAverageScore()
        {
            float totalScore = 0;

            foreach (float score in _studentExamScores)
                totalScore += score;

            return totalScore / _numberOfStudents;
        }
    }

    public class TemperatureTracker
    {
        private float[] _temperatures = new float[7];

        public TemperatureTracker(float[] tempsOnLastWeek)
        {
            _temperatures = tempsOnLastWeek;
        }

        public void ShowTemperatureOnLastWeek()
        {
            for (int index = 0; index < _temperatures.Length; index++)
                Logger.Info($"Day {index + 1} : {_temperatures[index]}");
        }
    }
    public class Array
    {   
        public static void SandBox()
        {
            StudentLog studentLog = new StudentLog(5);

            studentLog.Insert("Ajmal", 99.9f);
            studentLog.Insert("Asiya", 80.0f);
            studentLog.Insert("Haris", 56.7f);
            studentLog.Insert("Akumal", 100f);

            studentLog.EachStudent((string name, float score) =>
            {
                Logger.Info($"Name : {name}, Score : {score}");
            });

            Logger.Info($"Averag score: {studentLog.GetAverageScore()}");
        }
    }
}
