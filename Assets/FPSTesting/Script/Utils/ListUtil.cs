using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.FPSTesting.Script.Utils
{
    static class ListUtil<T>
    {
        static public T getRandomElement(List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count - 1)];
        }
    }
}
