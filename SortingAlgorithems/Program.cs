using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SortingAlgorithems
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            TimeAndPrintSort(Sorting.SelectionSort, "selection", 1000);
            TimeAndPrintSort(Sorting.InsertionSort,"insertion",10000);
            TimeAndPrintSort(Sorting.MergeSort, "Merge", 1000);

        }

        public delegate List<int> Sorting2(List<int> list);

        static void TimeAndPrintSort(Sorting2 sorting, string sortName, int listLength)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                var list = Sorting.GenerateRandomList(listLength);
                timer.Start();
                sorting(list);
                timer.Stop();
            }
            Console.WriteLine("1000 sorts of {1} at list length {2} took {0} ms", timer.ElapsedMilliseconds, sortName, listLength);

            timer.Restart();
            for (int i = 0; i < 10; i++)
            {
                var list2 = Sorting.GenerateRandomList(listLength * 10);
                timer.Start();
                sorting(list2);
                timer.Stop();
            }
            Console.WriteLine("10 sort of {1} at list length 10 * {2} took {0} ms", timer.ElapsedMilliseconds, sortName, listLength);
        }
        
        
       

    }

    public class Sorting
    {

        public static List<int> GenerateRandomList(int length = 100)
        {
            List<int> list = new List<int>();
            var r = new Random();
            for (int i = 0; i < length; i++)
            {
                list.Add(r.Next(100));
            }
            return list;
        }

        public static List<int> InsertionSort(List<int> list)
        {
            for (int index = 0; index < list.Count; index++)
            {
                for (int i = index; i > 0; i--)
                {
                    if (list[i]<list[i-1])
                    {
                        Swap(list,i,i-1);
                        break;
                    }
                }
            }
            return list;
        }

        public static List<int> SelectionSort(List<int> list)
        {
            for (int startingIndex = 0; startingIndex < list.Count; startingIndex++)
            {
                int minValue = list[startingIndex];
                int smallestIndex = startingIndex;

                for (int i = startingIndex; i < list.Count; i++)
                {
                    if (list[i] < minValue)
                    {
                        minValue = list[i];
                        smallestIndex = i;
                    }
                    
                }
                Swap<int>(list, smallestIndex, startingIndex);


            }
            return list;
        }

        public static List<int> MergeSort(List<int> list)
        {
            var listofLists = new List<List<int>>();
            foreach (var i in list)
            {
                listofLists.Add(new List<int>() {i});
            }

            while (listofLists.Count > 1)
            {
                var newListofLists = new List<List<int>>();
                for (int index = 0; index+1 < listofLists.Count; index= index+2)
                {
                    var newList = new List<int>();

                    while (listofLists[index].Count > 0 && listofLists[index + 1].Count > 0)
                    {
                        if (listofLists[index][0] < listofLists[index + 1][0])
                        {
                            newList.Add(listofLists[index][0]);
                            listofLists[index].RemoveAt(0);
                        }
                        else
                        {
                            newList.Add(listofLists[index+1][0]);
                            listofLists[index+1].RemoveAt(0);
                        }
                    }
                    for (int i = 0; i < listofLists[index].Count; i++)
                    {
                        newList.Add(listofLists[index][i]);
                    }
                    for (int i = 0; i < listofLists[index+1].Count; i++)
                    {
                        newList.Add(listofLists[index+1][i]);
                    }

                    newListofLists.Add(newList);
                   
                }
                if (listofLists.Count % 2 != 0)
                {
                    newListofLists.Add(listofLists[listofLists.Count-1]);
                }
                listofLists = newListofLists;
                
            }
            return listofLists[0];
            




        }



        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            var tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }


    }


}
