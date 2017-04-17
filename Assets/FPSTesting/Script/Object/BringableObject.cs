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
        public string name;

        public Mesh mesh;
        private MeshFilter meshFilter;

        public int price;

        public abstract void Use(ref Player player);

        private void Start()
        {
           meshFilter = gameObject.AddComponent<MeshFilter>();

            
            GetComponent<MeshFilter>().mesh = mesh;
        }
    }
}
