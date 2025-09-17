using MainProgram;

public class UnitTest1
{
    DefaultSortBaseCase listOne = new DefaultSortBaseCase();
    DefaultSortBaseCase listTwo = new DefaultSortBaseCase(6);

    [Fact]
    public void TestIsSortedMethod()
    {
        int[] newList = { 1, 2, 3, 4, 5 };
        Assert.True(DefaultSortBaseCase.IsSorted(newList, newList.Length));
    }

    [Fact]
    public void TestBaseCase()
    {
        int[] newList = { 1, 2, 3, 4, 5 };
        bool testBaseCase = listTwo.IsBaseCase(newList.Length, listTwo.baseCaseLength);
        Assert.True(testBaseCase);
    }

    [Fact]
    public void TestSplitListsMethod()
    {
        int[] newList = { 1, 2, 3, 4, 5 };
        int[] splitListOne = { 1, 2, 3 };
        int[] splitListTwo = { 4, 5 };
        listOne.SplitList(newList, out int[] firstHalf, out int[] secondHalf);
        Assert.Equal(splitListOne, firstHalf);
        Assert.Equal(splitListTwo, secondHalf);
    }

    [Fact]
    public void TestMergeListsMethod()
    {
        int[] newListOne = { 8 };
        int[] newListTwo = { 4 };
        int[] sortedList = { 4, 8 };
        Assert.True(DefaultSortBaseCase.IsSorted(listOne.MergeLists(newListOne, newListTwo), 2));
        Assert.Equal(sortedList, listOne.MergeLists(newListOne, newListTwo));
    }

    [Fact]
    public void TestFullSortListMethodWithMultipleLengths()
    {
        int[] newListOne = { 4, 3, 2 };
        Assert.True(DefaultSortBaseCase.IsSorted(listOne.SortList(newListOne), newListOne.Length));
        int[] newListTwo = { 4, 3, 2, 6, 7, 2, 9, };
        Assert.True(DefaultSortBaseCase.IsSorted(listOne.SortList(newListTwo), newListTwo.Length));
        int[] newListThree = { 4, 3, 2, 6, 7, 2, 9, 8, 5 };
        Assert.True(DefaultSortBaseCase.IsSorted(listOne.SortList(newListThree), newListThree.Length));
        int[] newListFour = { 4, 3, 2, 6, 7, 2, 9, 3, 3, 7, 5, 6, 1, 4, 5, 9 };
        Assert.True(DefaultSortBaseCase.IsSorted(listOne.SortList(newListFour), newListFour.Length));
    }
    
    [Fact]
    public void TestFullSortListMethodWithAnAlternateBaseCase()
    {
        int[] newListOne = { 4, 3, 2, 6, 7, 9, 2, 5, 3, 7};
        int[] newListOneFirstHalf = { 4, 3, 2, 6, 7 };
        int[] newListOneSecondHalf = { 9, 2, 5, 3, 7 };
        Assert.Equal(listTwo.MergeLists(newListOneFirstHalf, newListOneSecondHalf), listTwo.SortList(newListOne));
    }
}
