using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedAndMerged
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // First Example Given In Mission:
            int[][] array = new int[][]
            {
            new int[] { 1, 3, 5, 7},
            new int[] { 2, 4, 6, 8},
            new int[] { 0, 9, 10, 11}
            };
            

            /*
            // Second Example Given In Mission:
            int[][] array = new int[][]
            {
            new int[] {1, 5, 6, 8},
            new int[] {2, 4, 10, 12},
            new int[] {3, 7, 9, 11},
            new int[] {13, 14, 15, 16}
            };
            */

            /*
            // Example With Duplicate Numbers:
            int[][] array = new int[][]
            {
            new int[] {0, 0, 6, 8},
            new int[] {1, 4, 10, 10},
            new int[] {1, 8, 9, 11},
            new int[] {2, 15, 15, 16}
            };
            */

            /*
            // Example With Negative Numbers:
            int[][] array = new int[][]
            {
            new int[] {-90, -2, 6, 8},
            new int[] {-1, 4, 10, 12},
            new int[] {0, 7, 9, 11},
            new int[] {-14, -12, 15, 16}
            };
            */

            /*
            // Example With Only One Array:
            int[][] array = new int[][]
            {
            new int[] {-90, -2, 6, 8}
            };
            */

            /*
            // Example Which Array Is Null:
            int[][] array = null;
            */

            /*
            // Example Which Jagged Array Length Is 0:
            int[][] array = new int[0][];
            */

            int[] returned = array.SortedAndMerged(); // Run this function on each array to see the result.

            if (array != null && returned != null)
            {
                Console.WriteLine("Original Jagged Array:\n" + array.Print() + "After Merging And Sorting:\n" + string.Join(",", returned));
            }

            else
            {
                Console.WriteLine("NULL!!!");
            }
        }
    }

    public static class ex
    {
        public static int[] SortedAndMerged(this int[][] array)
        {
            if (array != null)
            {
                int length = array.Length;

                if (length != 0)
                {
                    if (length != 1)
                    {
                        List<int> list = array[0].ToList();
                        int sizeOfEachArray = array[0].Length;
                        int[] ReturnedArray = new int[length * sizeOfEachArray];

                        for (int i = 0; i < sizeOfEachArray; i++)
                        {
                            for (int j = 1; j < length; j++)
                            {
                                list.InsertIntoOrderedList(array[j][i]);
                            }
                        }

                        ReturnedArray = list.ToArray();
                        return ReturnedArray;
                    }

                    else
                    {
                        return array[0];
                    }
                }

                else
                {
                    return null;
                }
            }
            
            else
            {
                return null;
            }
        }
        public static void InsertIntoOrderedList(this List<int> list, int value)
        {
            if (list == null)
            {
                list = new List<int>();
                list.Add(value);
                return;
            }

            else if (list[list.Count - 1] <= value)
            {
                list.Add(value);
                return;
            }

            else if (list[0] >= value)
            {
                list.Insert(0, value);
                return;
            }

            int left = 0;
            int right = list.Count;
            int middle = 0;
            int mod = 0;

            while (left <= right)
            {
                middle = (left + right) / 2;

                if (value > list[middle])
                {
                    mod = 1;
                    left = middle + 1;
                }
                
                else if (value < list[middle])
                {
                    mod = 0;
                    right = middle - 1;
                }
                
                else
                {
                    break;
                }
            }

            middle += mod;
            list.Insert(middle, value);
        }

        public static string Print(this int[][] array)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < array.Length; row++)
            {
                sb.Append("Row(" + row + "):");
                sb.Append(string.Join(",", array[row]));
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
