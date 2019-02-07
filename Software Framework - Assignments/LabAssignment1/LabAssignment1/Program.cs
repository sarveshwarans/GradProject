using System;
using System.Collections.Generic;

namespace LabAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize two sets.
            Console.WriteLine("\nEnter the number of elements in Set A");
            int iNum = default;
            while (!int.TryParse(Console.ReadLine(), out iNum))
            {
                Console.WriteLine("\nEnter a valid number!");
            }
            IntegerSet set1 = InputSet(iNum);
            Console.WriteLine("\nEnter the number of elements in Set B");
            while (!int.TryParse(Console.ReadLine(), out iNum))
            {
                Console.WriteLine("\nEnter a valid number!");
            }
            IntegerSet set2 = InputSet(iNum);
            IntegerSet union = set1.Union(set2);
            IntegerSet intersection = set1.Intersection(set2);

            // Prepare output.
            Console.WriteLine("\nSet A contains elements:");
            Console.WriteLine(set1.ToString());
            Console.WriteLine("\nSet B contains elements:");
            Console.WriteLine(set2.ToString());
            Console.WriteLine("\nUnion of Set A and Set B contains elements:");
            Console.WriteLine(union.ToString());
            Console.WriteLine("\nIntersection of Set A and Set B contains elements:");
            Console.WriteLine(intersection.ToString());

            // Test whether two sets are equal.
            if (set1.IsEqualTo(set2))
                Console.WriteLine("\nSet A is equal to set B");
            else
                Console.WriteLine("\nSet A is not equal to set B");

            // Test insert and delete.
            Console.WriteLine("\nInserting 77 into set A...");
            set1.InsertElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            Console.WriteLine("\nDeleting 77 from set A...");
            set1.DeleteElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            // Test constructor.
            int[] intArray = { 25, 67, 2, 9, 99, 105, 45, -5, 100, 1 };
            IntegerSet set3 = new IntegerSet(intArray);

            Console.WriteLine("\nNew Set contains elements:");
            Console.WriteLine(set3.ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// Get the user input and fill the set with TRUE/FALSE by using InserElement()
        /// </summary>
        /// <param name="iNumSet"></param>
        /// <returns> Returns IntegerSet object </returns>
        private static IntegerSet InputSet(int iNumSet)
        {
            IntegerSet iSet = new IntegerSet();
            // Get the number of elements in the set.
            Console.WriteLine("\nEnter the Elements");
            for (int i=0; i<iNumSet;i++)
            {
                int iNum = default;
                while (!int.TryParse(Console.ReadLine(), out iNum))
                {
                    Console.WriteLine("\nEnter a valid number!");
                }
                // Build the IntergerSet object with TRUE/FALSE value by passing the input elements to InsertElement()
                iSet.InsertElement(iNum);
            }
            return iSet;
        }
    }
}
