using Game.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Game.UI.Windows.Tabs
{
    public class TabsGroup<T> : IGroup<T> where T : Tab
    {
        public ReadOnlyCollection<T> Elements => _elements.AsReadOnly();
        public Type ElementsType => _elementsType;

        private List<T> _elements;
        private Type _elementsType;

        private int _firstAddedElementSiblingIndex;
        private int _lastAddedElementSiblingIndex;

        //TODO Add tabs sorted as an interface

        public TabsGroup(Type elementsType)
        {
            _elements = new List<T>();
            _elementsType = elementsType;
        }

        public void Add(T element)
        {
            if (element.Menu.GetType() != ElementsType)
            {
                throw new Exception($"{element} type is not {ElementsType}! Group can contain only same type of elements!");
            }

            _elements.Add(element);

            if (element == _elements[0])
            {
                _firstAddedElementSiblingIndex = _elements[0].transform.GetSiblingIndex();
                _lastAddedElementSiblingIndex = _firstAddedElementSiblingIndex;
            }

            element.transform.SetSiblingIndex(_lastAddedElementSiblingIndex);
            _lastAddedElementSiblingIndex++;
        }

        public void Remove(T element)
        {
            _elements.Remove(element);
        }
    }
}
