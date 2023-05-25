using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ObjectPooling
{
    public interface ILimitedObjectPool<T> : IObjectPool<T> where T : MonoBehaviour
    {
        public void Initialize();
        public bool TryPool(T element);
        public bool TryUnpool(T element, out T unpooledElement);
        public bool TryUnpool(Type elementType, out T unpooledElement);
        public bool TryUnpoolLast(out T element);
        public bool IsFull();
        public bool HasEmptySlot(out int index);
    }
}