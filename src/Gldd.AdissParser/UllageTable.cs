using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldd.AdissParser
{
    public class UllageTable
    {
        //other conditions to test either throw or set limits
        //if (index == -1) //value less than the lowest //most likely a negative value
        //if (index > List.Count()) //value greater than highest

        //https://stackoverflow.com/questions/967047/how-to-perform-a-binary-search-on-ilistt
        //https://stackoverflow.com/questions/14930881/binarysearch-how-to-find-the-value-in-the-array-between-the-two-neighbors
        //https://stackoverflow.com/questions/4306094/find-closest-index-by-difference-with-binarysearch

        private readonly SortedList<double, double> sortByHeight;
        private readonly SortedList<double, double> sortByVolume;
        public UllageTable(IEnumerable<UllageRecord> ullageTable)
        {
            sortByHeight = new SortedList<double, double>();
            sortByVolume = new SortedList<double, double>();
            foreach (UllageRecord ullageRecord in ullageTable)
            {
                sortByHeight.Add(ullageRecord.Height, ullageRecord.Volume);
                sortByVolume.Add(ullageRecord.Volume, ullageRecord.Height);
            }
        }

        public double LookupVolume(double height)
        {
            int index = sortByHeight.Keys.BinarySearch(height);
            if (index >= 0)
            {
                return sortByHeight[height];
            }
            else
            {
                int ceilingIndex = Math.Abs(index) - 1;
                int floorIndex = Math.Abs(index) - 2;
                if (ceilingIndex == sortByHeight.Count()) ceilingIndex -= 2;
                if (floorIndex == -1) floorIndex = 1;
                KeyValuePair<double, double> ullageCeiling = sortByHeight.ElementAt(ceilingIndex);
                KeyValuePair<double, double> ullageFloor = sortByHeight.ElementAt(floorIndex);

                double h1 = ullageFloor.Key;
                double h2 = ullageCeiling.Key;
                double v1 = ullageFloor.Value;
                double v2 = ullageCeiling.Value;
                double hx = height;
                return (hx - h1) / (h2 - h1) * (v2 - v1) + v1;
            }
        }

        public double LookupHeight(double hopperVolume)
        {
            int index = sortByVolume.Keys.BinarySearch(hopperVolume);
            if (index >= 0)
            {
                return sortByVolume[hopperVolume];
            }
            else
            {
                int ceilingIndex = Math.Abs(index) - 1;
                int floorIndex = Math.Abs(index) - 2;
                if (ceilingIndex == sortByHeight.Count()) ceilingIndex -= 2;
                KeyValuePair<double, double> ullageCeiling = sortByVolume.ElementAt(ceilingIndex);
                KeyValuePair<double, double> ullageFloor = sortByVolume.ElementAt(floorIndex);

                double h1 = ullageFloor.Value;
                double h2 = ullageCeiling.Value;
                double v1 = ullageFloor.Key;
                double v2 = ullageCeiling.Key;
                double vx = hopperVolume;
                return (vx - v1) / (v2 - v1) * (h2 - h1) + h1;
            }
        }


    }

    public static class IListExtensions
    {
        //https://stackoverflow.com/questions/967047/how-to-perform-a-binary-search-on-ilistt
        /// <summary>
        /// Performs a binary search on the specified collection.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <typeparam name="TSearch">The type of the searched item.</typeparam>
        /// <param name="list">The list to be searched.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="comparer">The comparer that is used to compare the value with the list items.</param>
        /// <returns></returns>
        public static int BinarySearch<TItem, TSearch>(this IList<TItem> list, TSearch value, Func<TSearch, TItem, int> comparer)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            int lower = 0;
            int upper = list.Count - 1;

            while (lower <= upper)
            {
                int middle = lower + (upper - lower) / 2;
                int comparisonResult = comparer(value, list[middle]);
                if (comparisonResult < 0)
                {
                    upper = middle - 1;
                }
                else if (comparisonResult > 0)
                {
                    lower = middle + 1;
                }
                else
                {
                    return middle;
                }
            }

            return ~lower;
        }

        /// <summary>
        /// Performs a binary search on the specified collection.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="list">The list to be searched.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns></returns>
        public static int BinarySearch<TItem>(this IList<TItem> list, TItem value)
        {
            return BinarySearch(list, value, Comparer<TItem>.Default);
        }

        /// <summary>
        /// Performs a binary search on the specified collection.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="list">The list to be searched.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="comparer">The comparer that is used to compare the value with the list items.</param>
        /// <returns></returns>
        public static int BinarySearch<TItem>(this IList<TItem> list, TItem value, IComparer<TItem> comparer)
        {
            return list.BinarySearch(value, comparer.Compare);
        }
    }
}
