using System;
using System.Collections.Generic;

public delegate bool Criteria<T>(T item);

public class Example
{
    public static void Main()
    {
        Repository<int> repository = new Repository<int>();

        repository.Add(1);
        repository.Add(2);
        repository.Add(3);


        List<int> results = repository.Find(x => x > 2);

        foreach (int result in results)
        {
            Console.WriteLine(result);
        }
    }
}