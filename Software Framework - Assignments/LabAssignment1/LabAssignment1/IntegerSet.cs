using System;
using System.Linq;
using System.Text;

namespace LabAssignment1
{

    class IntegerSet
    {
        bool[] boolArray;
        private const int MAXSIZE = 101;

        /// <summary>
        /// Initialize all the elements of the array with the default value - FALSE.
        /// </summary>
        public IntegerSet()
        {
            boolArray = new bool[MAXSIZE];
        }

        /// <summary>
        /// Initialize all the elements of the array with the default value - FALSE. 
        /// Assign the value of the arrays element to TRUE if it the given input falls in the accepted range.
        /// </summary>
        /// <param name="intArray"></param>
        public IntegerSet(int[] intArray)
        {
            // Initialize all the elements of the array with the default value - FALSE.
            boolArray = new bool[MAXSIZE];
            foreach (int element in intArray)
            {
                if (element < MAXSIZE && element >= 0)
                    // Assign the value of the arrays element to TRUE if it the given input falls in the accepted range.
                    boolArray[element] = true;
            }
        }

        /// <summary>
        /// Assign the input array to the IntegerSet's boolArray.
        /// </summary>
        /// <param name="bArray"></param>
        public IntegerSet(bool[] bArray)
        {
            // Assign the input array to the IntegerSet's boolArray.
            this.boolArray = bArray;
        }

        /// <summary>
        /// Set the value of the boolArray's element to TRUE - to indicate that the new element is added to the set.
        /// </summary>
        /// <param name="e"></param>
        public void InsertElement(int e)
        {
            // Set the value of the boolArray's element to TRUE - to indicate that the new element is added to the set.
            if(e<101 && e>0)
                boolArray[e] = true;
        }

        /// <summary>
        /// Set the value of the boolArray's element to FALSE - to indicate that the new element is deleted from the set.
        /// </summary>
        /// <param name="e"></param>
        public void DeleteElement(int e)
        {
            // Set the value of the boolArray's element to FALSE - to indicate that the new element is deleted from the set.
            boolArray[e] = false;
        }

        /// <summary>
        /// To check if both the input sets are equal or not.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> Boolean value based on the input set. </returns>
        public bool IsEqualTo(IntegerSet obj)
        {
            IntegerSet iSet = (IntegerSet)obj;
            for (int i = 0; i < MAXSIZE; i++)
            {
                if (this.boolArray[i] != iSet.boolArray[i])
                    // If any of the elements in both the sets are not equal, then return false
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns a string containing a set as a list of numbers separated by spaces.
        /// Only those elements that are present in the set are displayed.
        /// Empty set is represented by "---".
        /// </summary>
        /// <returns> Returns a String containing elements that are present in the set. If empty then "---". </returns>
        public string ToString()
        {
            string a = default;
            int iFalseCounter = 0;
            for(int i=0;i<this.boolArray.Length;i++)
            {
                if (this.boolArray[i] == true)
                    // Whenever the element value is TRUE, we append the value of a with the index of that element.
                    a += i + " ";
                else
                {
                    // Whenever the element value is FALSE, we increase the counter of iFalseCounter.
                    iFalseCounter++;
                }
            }
            // If the value of iFalseCounter is equal to the number of elements in the set, it means that the set is empty.
            if (iFalseCounter==this.boolArray.Length)
                // Return the value of a as "---"
                return a = "---";
            else
                // If there are any valid elements, then return the index of those elements.
                return a;
        }

        /// <summary>
        /// Union of two input sets are computed and stored in new set.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> Returns IntegerSet object </returns>
        public IntegerSet Union(IntegerSet obj)
        {
            // New set - tempArray is created with the default value - FALSE.
            bool[] tempArray = new bool[MAXSIZE];
            for(int i = 0; i < MAXSIZE; i++)
            {
                // Store the value of the new set based on the output of OR of the two input sets.
                tempArray[i] = this.boolArray[i] || obj.boolArray[i];
            }
            // Get the corresponding IntegerSet object.
            IntegerSet iSet = new IntegerSet(tempArray);
            return iSet;
        }

        /// <summary>
        /// Intersection of two input sets are computed and stored in new set.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> Returns IntegerSet object </returns>
        public IntegerSet Intersection(IntegerSet obj)
        {
            // New set - tempArray is created with the default value - FALSE.
            bool[] tempArray = new bool[MAXSIZE];
            for (int i = 0; i < MAXSIZE; i++)
            {
                // Store the value of the new set based on the output of AND of the two input sets.
                tempArray[i] = this.boolArray[i] && obj.boolArray[i];
            }
            // Get the corresponding IntegerSet object.
            IntegerSet iSet = new IntegerSet(tempArray);
            return iSet;
        }
    }
}
