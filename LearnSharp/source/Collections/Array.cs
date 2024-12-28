namespace LearnSharp.Collections
{
    using Logger;
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

    public sealed class InventoryManager
    {
        private string[] _products;
        private int[] _quantity;

        private int _numberOfProducts;

        private readonly int INVENTORY_MAX_CAPACITY;

        public InventoryManager(int inventoryCapacity)
        {
            INVENTORY_MAX_CAPACITY = inventoryCapacity;

            _products = new string[INVENTORY_MAX_CAPACITY];
            _quantity = new int[INVENTORY_MAX_CAPACITY];

            _numberOfProducts = 0;
        }

        public void AddProduct(string productName, int baseQuantity)
        {
            _products[_numberOfProducts] = productName;
            _quantity[_numberOfProducts] = baseQuantity;
            _numberOfProducts++;
        }

        public void ClearProduct(string productname)
        {
            for (int index = 0; index < _numberOfProducts; index++)
            {
                if (_products[index] == productname)
                {
                    for (;index < _numberOfProducts; index++)
                    {
                        _products[index] = _products[(index + 1)];
                        _quantity[index] = _quantity[(index + 1)];
                    }
                    _numberOfProducts--;
                    return;
                }
            }
        }

        public void UpdateProduct(string productname, int newQuantity)
        {
            for (int index = 0; index < _numberOfProducts; index++)
            {
                if (_products[index] == productname)
                {
                    _quantity[index] = newQuantity;
                    return;
                }
            }
        }

        public void InspectInventory()
        {
            for (int index = 0; index < _numberOfProducts; index++)
                Logger.Info($"Product : {_products[index]}, Quantity : {_quantity[index]}");
        }
    }
    public class Array
    {   
        public static void SandBox()
        {
            InventoryManager manager = new InventoryManager(10);

            manager.AddProduct("Apple", 10);
            manager.AddProduct("Orange", 40);
            manager.AddProduct("Grapes", 50);
            manager.AddProduct("PineApple", 20);

            manager.ClearProduct("PineApple");

            manager.UpdateProduct("Apple", 100);

            manager.InspectInventory();
        }
    }
}
