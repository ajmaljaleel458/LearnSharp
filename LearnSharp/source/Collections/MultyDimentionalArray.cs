namespace LearnSharp.Collections
{
    using Logger;

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
    public class MultyDimentionalArray
    {
        public static void SandBox()
        {
            MultyplcationTable tabble = new MultyplcationTable(10, 10);

            tabble.PrintTable();
        }
    }
}
