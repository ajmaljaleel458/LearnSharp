namespace LearnShar
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
            this.x = other.x;
        }

        public Vector3 Add(Vector3 other)
        {
            return new Vector3(this.x + other.x,
                this.y + other.y, this.z + other.z);
        }

        public override string ToString()
        {
            return $"x:{this.x}, y:{this.y}, z:{this.z}";
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