using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DemoTimeComplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 200000;

            while (true)
            {
                Stopwatch stopWatch = new Stopwatch();
                Console.WriteLine("Enter 'q' to exit program");
                Console.Write("Select sorting method (linq/selectionsort): ");
                var method = Console.ReadLine();

                if (string.Equals(method, "q"))
                {
                    break;
                }
                if(string.Equals(method, "linq"))
                {
                    var list = CreateList(size).ToList();

                    stopWatch.Restart();
                    list.Sort();
                }
                else
                {
                    var array = CreateList(size).ToArray();

                    var selectionSort = new SelectionSort(array);
                    stopWatch.Restart();
                    selectionSort.Sort();
                }

                stopWatch.Stop();
                var timeSpan = stopWatch.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
                    timeSpan.Milliseconds / 10);
                Console.WriteLine($"RunTime {elapsedTime}");
                Console.WriteLine("------------------");
                Console.WriteLine();
            }    
        }

        private static IEnumerable<int> CreateList(int size)
        {
            var list = new List<int>();

            for (int i = size; i >= 1; i--)
            {
                list.Add(i);
            }
            
            return list;
        }

        private class SelectionSort
        {
            private int[] _data;

            public SelectionSort(int[] data)
            {
                _data = data;
            }

            public int[] Sort()
            {
                int smallest;
                for (int i = 0; i < _data.Length - 1; i++)
                {
                    smallest = i;
                    for (int index = i + 1; index < _data.Length; index++)
                    {
                        if (_data[index] < _data[smallest])
                        {
                            smallest = index;
                        }
                    }
                    Swap(i, smallest);
                }

                return _data;
            }

            private void Swap(int first, int second)
            {
                int temporary = _data[first];
                _data[first] = _data[second];
                _data[second] = temporary;
            }
        }
    }
}
