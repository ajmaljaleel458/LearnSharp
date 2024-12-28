namespace LearnSharp.Collections
{
    using Logger;
    using System;

    public class MultyplcationTable
    {
        private int[,] _table;

        public MultyplcationTable(int number, int max_multyplare)
        {
            _table = new int[max_multyplare, 3];
            FillTable(number);
        }

        private void FillTable(int number)
        {
            for (int row = 0; row < _table.GetLength(0); row++)
            {
                _table[row, 0] = number;

                _table[row, 1] = (row + 1);

                _table[row, 2] = number * (row + 1);
            }
        }

        public void PrintTable()
        {
            for (int row = 0; row < _table.GetLength(0); row++)
            {
                Logger.Info($"{_table[row, 0]} * {_table[row, 1]} = {_table[row, 2]}");
            }
        }
    }

    public sealed class ClassRoom
    {
        private Seat[,] _seats;

        private int _absenties;

        private int numberOfRows, numberOfCols;
        private class Student
        {
            public Student(string name, int rollNum)
            {
                this.name = name;
                this.rollNum = rollNum;
            }

            public string name;

            public int rollNum;
        }
        private sealed class Seat
        {
            public Student student;

            public int row, col;
        }

        public ClassRoom(int numberOfRow, int numberOfCol)
        {
            this.numberOfRows = numberOfRow;
            this.numberOfCols = numberOfCol;

            _seats = new Seat[numberOfRow, numberOfCol];

            for (int row = 0; row < _seats.GetLength(0); row++)
                for (int col = 0; col < _seats.GetLength(1); col++)
                    _seats[row, col] = new Seat() { row = row, col = col };

            _absenties = this.numberOfRows * this.numberOfCols;
        }

        public void ShowStudentDetails(string name)
        {
            for (int row = 0; row < _seats.GetLength(0); row++)
                for (int col = 0; col < _seats.GetLength(1); col++)
                    if (_seats[row, col].student.name == name)
                    {
                        Logger.Info($"Name: {_seats[row, col].student.name}, Roll No: {_seats[row, col].student.rollNum}");
                        return;
                    }
        }

        public void JoinClass(string name, int rollNum)
        {
            Random randomSeatAllocator = new Random();

            while (true)
            {
                int row = randomSeatAllocator.Next(0, numberOfRows);
                int col = randomSeatAllocator.Next(0, numberOfCols);

                if (_seats[row, col].student == null)
                {
                    _seats[row, col].student = new Student(name, rollNum);
                    _absenties--;
                    return;
                }
            }
        }

        public void PrintStudentsPresent()
        {
            for (int row = 0; row < _seats.GetLength(0); row++)
            {
                for (int col = 0; col < _seats.GetLength(1); col++)
                {
                    if (_seats[row, col].student != null)
                    {
                        Logger.Info($"Name : {_seats[row, col].student.name}");
                    }
                }
            }
        }

    }
    public class MultyDimentionalArray
    {
        public static void SandBox()
        {
            ClassRoom mathClass = new ClassRoom(8, 5);

            mathClass.JoinClass("Ajmal", 3);

            mathClass.PrintStudentsPresent();
        }
    }
}
