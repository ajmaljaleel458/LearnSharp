namespace LearnSharp.ObjectOrientedPrograming
{
    public class Vector3
    {
        float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            return;
        }

        public Vector3(Vector3 other)
        {
            x = other.x;
        }

        public Vector3 Add(Vector3 other)
        {
            return new Vector3(x + other.x,
                y + other.y, z + other.z);
        }

        public override string ToString()
        {
            return $"x:{x}, y:{y}, z:{z}";
        }
    }

    public class Person
    {
        public string name;

        public int age;

        public string place;

        public Person()
        {
            name = "UnNamed";
            age = -1;
            place = "UnKnown";
        }
    }
}