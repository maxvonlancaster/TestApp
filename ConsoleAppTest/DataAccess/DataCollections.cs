using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.DataAccess
{
    // Collections are a different way of grouping data. Collections are how to store a large number of objects that are usually all the same type
    public class DataCollections
    {
        // 55 An array is the simplest way to create a collection of items of a particular type. An array is assigned a size when it is created and the elements	
        // in the array are accessed using an index or subscript value. An array instance is a C# object that is managed by reference. A program creates an	array
        // by declaring the array variable and then making the variable refer to an array instance. Square brackets ([ and ]) are used to declare the array and	
        // also create the array instance.
        // An array of value types (for example an array of integers) holds the values themselves within the array, whereas for an array of reference types 
        // (for example an array of objects) each element in the array holds a reference to the object. When an array is created, each element in the array 
        // is initialized to the default value for that type. Numeric elements are initialized to 0, reference elements to null, and Boolean elements to false.
        // Arrays implement the IEnumerable interface, so they can be enumerated using the foreach construction. Once created, an array has a fixed length that	
        // cannot be changed, but an array reference can be made to refer to a new array object. An array can be initialized when it is created. An array 
        // provides a Length property that a program can use to determine the length of the array. 
        // Any array that uses a single index to access the elements in the array is called a one dimensional array.
        public void ArrayExample()
        {
            // array of integers
            int[] intArray = new int[5];
            intArray[0] = 99;
            intArray[4] = 100;

            // use index to work through the array
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }

            // use foreach
            foreach (int elem in intArray)
            {
                Console.WriteLine(elem);
            }

            // initialize new array
            intArray = new int[] { 1, 2, 3, 4 };

            // Multidimansional arrays
            string[,] compass = new string[3, 3]
            {
                { "NW", "N", "NE" },
                { "W", "C", "E" },
                { "SW", "S", "SE" }
            };
            Console.WriteLine(compass[0, 0]); // prints NW
            Console.WriteLine(compass[2, 2]); // prints SE

            // Jagged arrays
            // You can view a two-dimensional array as an array of one dimensional arrays. A “jagged array” is a two-dimensional array in which each 
            // of the rows are a different length.
            int[][] jaggedArray = new int[][]
            {
                new int[]{ 1, 2, 3, 4, 4 },
                new int[]{ 5, 6},
                new int[]{ 0, 0, -1, 300, 300, 100, 0, 0, 0 }
            };
        }

        // 56 The usefulness of an array is limited by the way you must decide in advance the number of items that are to be stored in the array. The size of	
        // an array cannot be changed once it has been created (although you can use a variable to set the dimension of the array if you wish). The ArrayList 
        // class was created to address this issue. An ArrayList stores data in a dynamic structure that grows as more items are added to it. 
        // Items in an ArrayList are managed by reference and the reference that is used is of type	object. This means that an ArrayList can hold references	
        // to any type of object, since the object type is the base type of all of the types in C#. However, this can lead  some programming difficulties.	
        public void UseArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add("string");
            arrayList.Insert(index: 4, value: "value");

            foreach (var elem in arrayList)
            {
                Console.WriteLine(elem);
            }
        }


        // 57
        public void UseList()
        {

        }


        // 58
        public void DictionaryExample()
        {

        }

        // 59


        // 60


        // 61


        // 62


        // 63


    }
}
