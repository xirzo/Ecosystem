using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Game.Utilities
{
    public interface IGroup<T> where T : MonoBehaviour
    {
        ReadOnlyCollection<T> Elements { get; }
        Type ElementsType { get; }
        void Add(T element);
        void Remove(T element);
    }
}
