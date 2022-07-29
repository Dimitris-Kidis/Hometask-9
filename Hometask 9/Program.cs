
// Hometask #9

// 1. Create a generic collection class using Array or List ✅
// *. Add, Remove, Contains, IsEmpty, Length ✅
// 2. Get item at given index ✅
// 3. Set item at given index ✅
// 4. Swap Method ✅
// 4. Add a comparer

using System;
using System.Collections;
using System.Collections.Generic;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomCollection<Human> people = new();
            //Console.WriteLine(people.IsEmpty);
            
            



            var planeList = new CustomCollection<Plane>();

            planeList.Add(new Plane(1, "C", 46.24));
            planeList.Add(new Plane(3, "A", 23.11));
            planeList.Add(new Plane(2, "B", 64.74));

            Console.WriteLine(planeList.Get(1));
            Console.WriteLine(planeList.Get(1));
            Console.WriteLine(planeList.Get(2));

            planeList.SortBy(new NameComparer());
            Console.WriteLine(planeList.Get(0));
            Console.WriteLine(planeList.Get(1));
            Console.WriteLine(planeList.Get(2));

        }
    }
}

class Human
{
    public string Name { get; set; }
}

//class CustomCollection <T>
//{
//    private List<T> list = new();
//    private T[] arr;

//    public bool IsEmpty { 
//        get
//        {
//            return list?.Any() != true;
//        }
//    }

//    public int Length {
//        get
//        {
//            return (int)list.Count;
//        }
//    }



//    public void Add (T item)
//    {
//        list.Add(item);

//    }

//    public void Remove (int i)
//    {
//        list.RemoveAt(i);
//    }

//    public void Set (int i, T item)
//    {

//    }

//    public T Get (int i)
//    {
//        return list[i];
//    }

//    public void Swap (int i, int j)
//    {
//        T temp = list[i];
//        list[i] = list[j];
//        list[j] = temp;
//    }

//    public bool Cointains (T item)
//    {
//        return list.Contains(item);
//    }

//    public void SortBy (IComparer compare)
//    {
//        arr = list.ToArray();
//        Array.Sort(arr, compare);
//        list = arr.ToList();
//    }

//}


class CustomCollection<T>
{
    private T[] arr = new T[] { };

    public bool IsEmpty
    {
        get
        {
            return arr.Length == null ? true : false;
        }
    }

    public int Length
    {
        get
        {
            return arr.Length;
        }
    }



    public void Add(T item)
    {
        arr.Append(item);

    }

    public void Remove(int i)
    {
        arr = Array.FindAll(arr, a => !a.Equals(i)).ToArray();
    }

    public void Set(int i, T item)
    {
        arr.SetValue(item, i);
    }

    public T Get(int i)
    {
        return arr[i];
    }

    public void Swap(int i, int j)
    {
        T temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public bool Cointains(T item)
    {
        return arr.Contains(item);
    }

    public void SortBy(IComparer compare)
    {
        Array.Sort(arr, compare);
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


class NameComparer : IComparer
{
    int IComparer.Compare(object x, object y)
    {
        Plane animal1 = (Plane)x;
        Plane animal2 = (Plane)y;
        return String.Compare(animal1.ShortName, animal2.ShortName);
    }
}