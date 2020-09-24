using System.Collections.Generic;

namespace TowerDefenceLeoEcs.Extensions
{
    public static class ListExtension
    {
        public static T Random<T>(this List<T> list)
        {
            var listCount = list.Count;
            if (listCount == 0) return default;
            var randomIndex = UnityEngine.Random.Range(0, listCount);
            return list[randomIndex];
        }

        public static int RandomOnProbability(this List<int> list)
        {
            float total = 0;

            foreach (float elem in list)
            {
                total += elem;
            }

            float randomPoint = UnityEngine.Random.value * total;

            for (int i = 0; i < list.Count; i++)
            {
                if (randomPoint <= list[i])
                {
                    return i;
                }
                else
                {
                    randomPoint -= list[i];
                }
            }
            return list.Count - 1;
        }
    }
}