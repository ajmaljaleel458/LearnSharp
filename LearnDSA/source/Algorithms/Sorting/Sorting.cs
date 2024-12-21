namespace DataStructureAndAlgorith.Algorithms
{
    public static class Sorting
    {
        public static int[] BubbleSort(int[] array)
        {
            for (int leftIndex = 0; leftIndex < (array.Length - 1); leftIndex++)
            {
                for (int rightIndex = leftIndex; rightIndex < array.Length; rightIndex++)
                {
                    if (array[rightIndex] < array[leftIndex])
                    {
                        int temp = array[rightIndex];
                        array[rightIndex] = array[leftIndex];
                        array[leftIndex] = temp;
                    }
                }
            }

            return array;
        }
    }
}