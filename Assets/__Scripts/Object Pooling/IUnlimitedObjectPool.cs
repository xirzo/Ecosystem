using System;
using UnityEngine;

namespace Game.ObjectPooling
{
    public interface IUnlimitedObjectPool<T> : IObjectPool<T> where T : MonoBehaviour
    {
        public T Prefab { get; }
        public bool AutoExpand { get; set; }

        public void Pool(T element);
        public T Unpool();
        public T UnpoolLast();
    }
}