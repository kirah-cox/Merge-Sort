namespace MainProgram;
public class Program
{
    static void Main()
    {
        
    }
}


public class DefaultSortBaseCase
{
    public int baseCaseLength { get; set; }

    public DefaultSortBaseCase(int baseLength = 2)
    {
        baseCaseLength = baseLength;
    }

    public bool IsBaseCase(int valuesLength, int baseCaseLength)
    {
        return valuesLength < baseCaseLength;
    }

    public int[] HandleBaseCase(int[] values)
    {
        return values;
    }

    public static bool IsSorted(int[] numberList, int listLength)
    {
        for (int i = 0; i < listLength - 1; i++)
        {
            if (numberList[i] > numberList[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public static int[] InsertionSort(int[] numberList, int listLength)
    {
        int storedNumber;
        int positionNumber;
        int[] sortedList = numberList;

        while (!IsSorted(numberList, listLength))
        {
            for (int i = 1; i < listLength; i++)
            {
                positionNumber = i - 1;
                while (numberList[i] < numberList[positionNumber])
                {
                    storedNumber = numberList[i];
                    numberList[i] = numberList[positionNumber];
                    numberList[positionNumber] = storedNumber;
                    if (positionNumber - 1 >= 0)
                    {
                        positionNumber--;
                    }
                }
            }
        }
        return sortedList;
    }

    public int[] SortList(int[] values)
    {
        if (!IsBaseCase(values.Length, baseCaseLength))
        {
            SplitList(values, out int[] firstHalf, out int[] secondHalf);
            return MergeLists(SortList(firstHalf), SortList(secondHalf));
        }
        return values;
    }

    public void SplitList(int[] values, out int[] firstHalf, out int[] secondHalf)
    {
        int halfLength = values.Length / 2;
        bool oddNumber = false;

        if (values.Length % 2 == 1)
        {
            firstHalf = new int[halfLength + 1];
            oddNumber = true;
        }
        else
        {
            firstHalf = new int[halfLength];
        }
        secondHalf = new int[halfLength];

        for (int i = 0; i < firstHalf.Length; i++)
        {
            firstHalf[i] = values[i];
        }

        for (int i = 0; i < secondHalf.Length; i++)
        {
            if (oddNumber)
            {
                secondHalf[i] = values[i + halfLength + 1];
            }
            else
            {
                secondHalf[i] = values[i + halfLength];
            }
        }
    }

    public int[] MergeLists(int[] valuesListOne, int[] valuesListTwo)
    {
        int indexListOne = 0;
        int indexListTwo = 0;
        int indexNewList;

        int[] newList = new int[valuesListOne.Length + valuesListTwo.Length];

        for (indexNewList = 0; indexNewList < newList.Length; indexNewList++)
        {
            if (indexListOne == valuesListOne.Length)
            {
                int[] restOfList = new int[valuesListTwo.Length - indexListTwo];
                int restOfListIndex = 0;

                for (int j = indexListTwo; j <= valuesListTwo.Length - 1; j++)
                {
                    restOfList[restOfListIndex] = valuesListTwo[j];
                    restOfListIndex++;
                }

                for (int j = 0; j < restOfList.Length; j++)
                {
                    int[] restOfListSorted = InsertionSort(restOfList, restOfList.Length);
                    newList[indexNewList] = restOfListSorted[j];
                    indexNewList++;
                }
            }
            else if (indexListTwo == valuesListTwo.Length)
            {
                int[] restOfList = new int[valuesListOne.Length - indexListOne];
                int restOfListIndex = 0;

                for (int j = indexListOne; j <= valuesListOne.Length - 1; j++)
                {
                    restOfList[restOfListIndex] = valuesListOne[j];
                    restOfListIndex++;
                }

                for (int j = 0; j < restOfList.Length; j++)
                {
                    int[] restOfListSorted = InsertionSort(restOfList, restOfList.Length);
                    newList[indexNewList] = restOfListSorted[j];
                    indexNewList++;
                }
            }
            else
            {
                if (valuesListOne[indexListOne] <= valuesListTwo[indexListTwo])
                {
                    newList[indexNewList] = valuesListOne[indexListOne];
                    indexListOne++;
                }
                else
                {
                    newList[indexNewList] = valuesListTwo[indexListTwo];
                    indexListTwo++;
                }
            }
        }
        return newList;
    }
}