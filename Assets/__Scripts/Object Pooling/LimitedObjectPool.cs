using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.ObjectPooling
{
    public class LimitedObjectPool<T> : ILimitedObjectPool<T> where T : MonoBehaviour
    {
        public event Action<T> OnPooled;
        public event Action<T> OnUnpooled;

        private List<T> _pool;
        private List<T> _initialElements;
        private Transform _container;

        private int _capacity;

        public LimitedObjectPool(Transform container = null, int capacity = 1, List<T> initialElements = null)
        {
            _container = container;
            _capacity = capacity;
            _initialElements = initialElements;
            _pool = new List<T>();

            Initialize();
        }

        public void Initialize()
        {
            if (_initialElements != null)
            {
                if (_initialElements.Count > _capacity)
                    throw new Exception($"Number of initial elements is higher than capacity!");

                for (int i = 0; i < _initialElements.Count; i++)
                {
                    Instantiate(_initialElements[i]);
                }
            }
        }

        public T GetElement(int index)
        {
            try
            {
                if (HasElementWithIndex(index) == false)
                    return null;

                return _pool[index];
            }

            catch
            {
                return null;
            }
        }

        public int GetElementIndex(T element)
        {
            return _pool.IndexOf(element);
        }

        public bool HasElementWithIndex(int index)
        {
            try
            {
                if (_pool[index] != null)
                    return true;
            }
            catch
            {
                return false;
            }

            return false;
        }

        public bool HasEmptySlot(out int index)
        {
            if (IsFull() == true)
            {
                index = -1;
                return false;
            }

            for (int i = 0; i < _capacity; i++)
            {
                if (_pool[i] == null)
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        public bool IsFull()
        {
            if (_pool.Count >= _capacity)
                return true;

            return false;
        }

        public bool TryPool(T element)
        {
            if (IsFull() == false)
            {
                Pool(element);
                return true;
            }

            //Debug.LogWarning($"There is space to pool element with name: {element.name}");
            return false;
        }

        public bool TryUnpool(T element, out T unpooledElement)
        {
            T foundItem = _pool.Find(item => item == element);

            if (foundItem != null)
            {
                Unpool(foundItem);
                unpooledElement = foundItem;
                return true;
            }

            //Debug.LogWarning($"There is no element such as: {element}");
            unpooledElement = null;
            return false;
        }

        public bool TryUnpool(Type elementType, out T unpooledElement)
        {
            foreach (T element in _pool)
            {
                if (element.GetType() == elementType)
                {
                    unpooledElement = element;
                    Unpool(element);
                    return true;
                }
            }

            //Debug.LogWarning($"There is element with such type: {elementType}");
            unpooledElement = null;
            return false;
        }

        public bool TryUnpoolLast(out T unpooledElement)
        {
            T lastElement;

            try
            {
                lastElement = _pool.Last();
            }

            catch
            {
                //Debug.LogWarning($"There is no elements in pool!");
                unpooledElement = null;
                return false;
            }

            unpooledElement = lastElement;
            Unpool(unpooledElement);
            return true;
        }

        private void Pool(T element)
        {
            _pool.Add(element);
            element.gameObject.SetActive(false);
            OnPooled?.Invoke(element);

            //Debug.Log($"{element} was pooled, it`s index is {_pool.IndexOf(element)}!");
        }
        private void Unpool(T element)
        {
            _pool.Remove(element);
            element.gameObject.SetActive(true);
            OnUnpooled?.Invoke(element);

            //Debug.Log($"{element} was unpooled!");
        }
        private T Instantiate(T prefab)
        {
            T createdObject = Object.Instantiate(prefab, _container.position, _container.rotation, _container);
            TryPool(createdObject);
            return createdObject;

        }
    }
}
