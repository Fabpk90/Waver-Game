using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.FPSTesting.Object
{
    public abstract class BringableObject : MonoBehaviour
    {
        public float weight;
        public Sprite image;
        public string description;

        public int price;

        public abstract void Use(ref Player player);
    }
}
