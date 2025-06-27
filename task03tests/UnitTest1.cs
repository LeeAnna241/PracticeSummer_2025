using Xunit;
using task03;

public class IteratorTests
{
    //стандартный итератор
    [Fact]
    public void CustomCollection_GetEnumerator_ReturnsAllItems()
    {
        var collection = new CustomCollection<int>();
        collection.Add(1);
        collection.Add(2);

        var result = new List<int>();
        foreach (var item in collection)
        {
            result.Add(item);
        }

        Assert.Equal(new[] { 1, 2 }, result);
    }

    [Fact]
    public void GetReverseEnumerator_ReturnsItemsInReverseOrder()
    {
        var collection = new CustomCollection<int>();
        collection.Add(1);
        collection.Add(2);

        var result = collection.GetReverseEnumerator().ToList();
        Assert.Equal(new[] { 2, 1 }, result);
    }

    //генерирует последовательность чисел
    [Fact]
    public void GenerateSequence_ReturnsCorrectSequence()
    {
        var sequence = CustomCollection<int>.GenerateSequence(5, 3);
        sequence.ToList();
        Assert.Equal(new[] { 5, 6, 7 }, sequence);
    }

    //фильтрует коллекцию
    [Fact]
    public void FilterAndSort_ReturnsFilteredAndSortedItems()
    {
        var collection = new CustomCollection<int>();
        collection.Add(3);
        collection.Add(1);
        collection.Add(2);

        var result = collection.FilterAndSort(x => x > 1, x => x);
        result.ToList();
        Assert.Equal(new[] { 2, 3 }, result);
    }
}