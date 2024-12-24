namespace LearnSharp.ObjectOrientedPrograming
{
    public class Brototype
    {
        public class Course
        {
            private string _courseName;

            public void SetCourse()
            {
                
            }

            public int courseDuration;

            public int coursePrice;
        }

        public enum Courses
        {
            MEARN = 0,
            MEAN,
            DJANGO,
            DATASCIENCE,
            GAMEDEVELOPMENT
        }

        public enum Duration
        {
            HALFYEAR = 0,
            FULLYEAR = 1
        }

        public class Student
        {
            public int id;

            public string name;

            public Course course;

            public Student(string name, Courses course, Duration duration)
            {
                this.course = new Course();
            }
        }
    }
}
