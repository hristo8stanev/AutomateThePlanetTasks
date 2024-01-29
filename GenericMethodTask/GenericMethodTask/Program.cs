using System;
using System.Collections;

public class DataRepo<T> where T: IEnumerable<T>
{
    public T Data { get; set; }
}
