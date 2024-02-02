using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable;
public class Hashtable<K, V>
{
    private double LoadFactor => 0.75;
    private int InitialCapacity => 16;

    private const string existingElementMessage = "Element with this key already exists in the HashTable";
    private const string notFoundKeyMessage = "The key was not found in the table";
    private List<KeyValuePair<K, V>>[] buckets;
    private int size;
    private int count;

    public Hashtable()
    {
        buckets = new List<KeyValuePair<K, V>>[InitialCapacity];
        size = 0;
    }

    private int GetIndex(K key)
    {
        int hashCode = key.GetHashCode();

        return Math.Abs(hashCode % buckets.Length);
    }

    public void Add(K key, V value)
    {
        int index = GetIndex(key);

        if (buckets[index] == null)
        {
            buckets[index] = new List<KeyValuePair<K, V>>();
        }

        foreach (var pair in buckets[index])
        {
            if (pair.Key.Equals(key))
            {
                throw new ArgumentException(message: Hashtable<K, V>.existingElementMessage);
            }
        }

        buckets[index].Add(new KeyValuePair<K, V>(key, value));
        size++;

        if ((double)size / buckets.Length > LoadFactor)
        {
            Resize();
        }
    }

    private void Resize()
    {
        int newSize = buckets.Length * 2;
        var newBuckets = new List<KeyValuePair<K, V>>[newSize];

        foreach (var bucket in buckets)
        {
            if (bucket != null)
            {
                foreach (var pair in bucket)
                {
                    int newIndex = GetIndex(pair.Key);
                    if (newBuckets[newIndex] == null)
                    {
                        newBuckets[newIndex] = new List<KeyValuePair<K, V>>();

                    }
                    newBuckets[newIndex].Add(pair);
                }
            }
        }

        buckets = newBuckets;
    }

    public V Find(K key)
    {
        int index = GetIndex(key);
        if (buckets[index] != null)
        {
            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
        }
        throw new ArgumentException(Hashtable<K, V>.notFoundKeyMessage);
    }

    public void Remove(K key)
    {
        int index = GetIndex(key);
        if (buckets[index] != null)
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[index][i].Key.Equals(key))
                {
                    buckets[index].RemoveAt(i);
                    size--;
                    return;
                }
            }
        }
        throw new ArgumentException(Hashtable<K, V>.notFoundKeyMessage);
    }

    public void Clear(K key)
    {

        int index = GetIndex(key);

        if (buckets[index] != null)
        {
            for (int i = 0; i < buckets[index].Count; i++)
            {
                if (buckets[index][i].Key.Equals(key))
                {
                    buckets[index].RemoveAt(i);
                    size--;
                    return;
                }
            }
        }
        throw new ArgumentException(Hashtable<K, V>.notFoundKeyMessage);
    }

    public int Count(K key)
    {
        int index = GetIndex(key);
        count = 0;

        if (buckets[index] != null)
        {
            for (int i = 0; i < buckets[index].Count; i++)
            {
                if (buckets[index][i].Key.Equals(key))
                {
                    count++;
                }
            }

            return count;
        }

        return 0;
    }
}