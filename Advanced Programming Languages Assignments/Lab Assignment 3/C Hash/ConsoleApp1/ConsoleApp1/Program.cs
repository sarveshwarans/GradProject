using System;
using System.Collections.Generic;
using System.Linq;

    
public class User 
{
    string Name;
    int Age;

    private class SpecialCompare : IComparer<User>
    {
        int IComparer<User>.Compare(User x, User y)
        {
            if (x.Age == y.Age)
                return y.Name.CompareTo(x.Name);
            else
                return x.Age.CompareTo(y.Age);

            throw new NotImplementedException();
        }
    }


    public User(string userName, int userAge)
    {
        this.Name   = userName;
        this.Age    = userAge;
    }
    static void Main()
    {
        Console.WriteLine("*** Sorted Double Array ***");
        double[] doubleArray = new double[] { 645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26 };
        Array.Sort(doubleArray);
        foreach (double i in doubleArray) Console.Write(i + " ");
        Console.WriteLine("\n");
        Console.WriteLine("*** Sorted UserNames In Ascending Order ***");
        string[] stringArray = new string[] { "Hal","Susann","Dwight","Kassandra","Lawrence","Cindy","Cory","Mac","Romana","Doretha","Danna",
            "Zara","Rosalyn","Risa","Benny","Juan","Natalie" };
        int[] ageArray = { 20, 31, 19, 21, 25, 22, 27, 19, 27, 32, 20, 23, 26, 24, 28, 33, 25 };
        Array.Sort(stringArray);
        foreach (string str in stringArray) Console.Write(str + " ");
        Console.WriteLine("\n");
        Console.WriteLine("*** Sorted UserNames In Descending Order Of Age ***");
        User[] users = new User[] { new User ("Hal", 20), new User ("Susann", 31),new User ("Dwight", 19), new User ("Kassandra", 21),
            new User("Lawrence", 25),new User("Cindy", 22),new User ("Cory", 27),new User ("Mac", 19), new User ("Romana", 27), new User ("Doretha", 32),
            new User("Danna", 20),new User ("Zara", 23),new User ("Rosalyn", 26),new User ("Risa", 24), new User ("Benny",28),
            new User ("Juan", 33),new User ("Natalie", 25) };

        IEnumerable<User> query = users.OrderByDescending(a => a, new SpecialCompare());
        foreach (User user in query) Console.Write(user.Name + user.Age + " ");
        Console.ReadKey();

    }

}
   
