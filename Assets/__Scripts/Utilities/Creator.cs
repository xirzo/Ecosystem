using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Utilities
{
    public class Creator<T> where T : MonoBehaviour
    {
        public Transform Container { get; set; }

        public Creator(Transform container)
        {
            Container = container;
        }

        public T Create(T prefab)
        {
            var newElement = Object.Instantiate(prefab, Container);
            return newElement;
        }
    }
}
