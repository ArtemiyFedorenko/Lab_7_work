public class Repository<T>
{
    private List<T> items;

    public Repository()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public List<T> Find(Criteria<T> criteria)
    {
        List<T> results = new List<T>();

        foreach (T item in items)
        {
            if (criteria(item))
            {
                results.Add(item);
            }
        }

        return results;
    }
}