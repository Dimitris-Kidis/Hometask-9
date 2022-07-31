
// Hometask #9

// 1. Create a generic collection class using Array or List ✅
// *. Add, Remove, Contains, Length ✅
// 2. Get item at given index ✅
// 3. Set item at given index ✅
// 4. Swap Method: by index and by value ✅
// 5. Add a comparer ✅

using System;
using System.Collections;
using System.Collections.Generic;


public class Program
{
    static void Main(string[] args)
    {
        var planeList = new CustomCollection<Plane>();

        var a = new Plane(1, "C", 46.24);
        var b = new Plane(3, "A", 23.11);
        var c = new Plane(2, "B", 64.74);

        planeList.Add(a);
        planeList.Add(b);
        planeList.Add(c);

        Console.WriteLine(planeList.Cointains(new Plane(5, "F", 54.24)));

        for (int i = 0; i < planeList.Length; i++)
        {
            Console.WriteLine(planeList[i]);
        }
        //planeList.Sort(new NameComparer());


        planeList.Swap(a, b);
        for (int i = 0; i < planeList.Length; i++)
        {
            Console.WriteLine(planeList[i]);
        }


        
        

        
    }
}


class Plane
{
    public int ID { get; set; }

    public string ShortName { get; set; }

    public double Speed { get; set; }

    public Plane(int ID, string shortName, double speed)
    {
        this.ID = ID;
        this.ShortName = shortName;
        this.Speed = speed;
    }


    public override string ToString()
    {
        return String.Format("ID: {0, 3} ShortName: {1, -9} Speed: {2, 3}", ID, ShortName, Speed);
    }
}

class NameComparer : Comparer<Plane>
{
    public override int Compare(Plane x, Plane y)
    {
        return String.Compare(x.ShortName, y.ShortName);
    }
}


//}class NameComparer : Comparer<Plane>
//{
//    int IComparer.Compare(object x, object y)
//    {
//        Plane plane1 = (Plane)x;
//        Plane plane2 = (Plane)y;
//        return String.Compare(x.ShortName, y.ShortName);
//    }
//}

// -------------------- List Implementation -----------------------
//class CustomCollection<T>
//{
//    private List<T> list = new();
//    private T[] arr;

//    public bool IsEmpty
//    {
//        get
//        {
//            return list?.Any() != true;
//        }
//    }

//    public int Length
//    {
//        get
//        {
//            return (int)list.Count;
//        }
//    }



//    public void Add(T item)
//    {
//        list.Add(item);

//    }

//    public void Remove(int i)
//    {
//        list.RemoveAt(i);
//    }

//    public void Set(int i, T item)
//    {
//        list[i] = item;
//    }

//    public T Get(int i)
//    {
//        return list[i];
//    }

//    public void Swap(int i, int j)
//    {
//        T temp = list[i];
//        list[i] = list[j];
//        list[j] = temp;
//    }

//    public bool Cointains(T item)
//    {
//        return list.Contains(item);
//    }

//    public void SortBy(IComparer compare)
//    {
//        arr = list.ToArray();
//        Array.Sort(arr, compare);
//        list = arr.ToList();
//    }

//    public void PrintAll ()
//    {
//        Console.WriteLine("\n\n\t\tPlanes Info");
//        for(int i = 0; i < list.Count; i++)
//        {
//            Console.WriteLine(list[i]);
//        }
//    }

//}

// ----------------------------------------------------------------



// -------------------- Array Implementation -----------------------

class CustomCollection<T>
{
    private const int DEFAULT_CAPACITY = 4;

    private T[] arr;

    private int SIZE;

    static readonly T[] emptyArray = new T[0];

    public int Length { get => SIZE; }

    public CustomCollection()
    {
        arr = emptyArray;
    }

    public CustomCollection(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentException("Invalid capacity");
        if (capacity == 0)
            arr = emptyArray;
        else
            arr = new T[capacity];
        SIZE = arr.Length;
    }

    public T this[int index]
    {
        get
        {
            if ((uint)index >= (uint)SIZE)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
            return arr[index];
        }
        set
        {
            if ((uint)index >= (uint)SIZE)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
            arr[index] = value;
        }
    }

    public void Add(T item)
    {
        if (SIZE == arr.Length)
            EnsureCapacity(SIZE + 1);
        arr[SIZE++] = item;
    }

    public void Remove(int index)
    {
        if ((uint)index >= (uint)SIZE)
        {
            throw new ArgumentOutOfRangeException("Invalid index");
        }
        Console.WriteLine("size" + SIZE);
        SIZE--;
        Array.Copy(arr, index + 1, arr, index, SIZE - index);
        arr[SIZE] = default(T);
    }

    public void Swap(T a, T b)
    {
        int first = Array.IndexOf(arr, a);
        int second = Array.IndexOf(arr, b);
        T temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
    }

    public void Swap(int indexFirst, int indexSecond)
    {
        T temp = arr[indexFirst];
        arr[indexFirst] = arr[indexSecond];
        arr[indexSecond] = temp;
    }

    public void Sort(IComparer<T> comparer)
    {
        Array.Sort<T>(arr, 0, Length, comparer);
    }

    private void EnsureCapacity(int min)
    {
        if (arr.Length < min)
        {
            int newCapacity = arr.Length == 0 ? DEFAULT_CAPACITY : arr.Length * 2;
            Capacity = newCapacity;
        }
    }
    private int Capacity
    {
        get
        {
            return arr.Length;
        }
        set
        {
            T[] newItems = new T[value];
            Array.Copy(arr, 0, newItems, 0, SIZE);
            arr = newItems;
        }
    }

    public bool Cointains(T item)
    {
        return arr.Contains(item);
    }

}

