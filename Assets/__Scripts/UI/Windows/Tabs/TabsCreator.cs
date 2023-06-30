using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using Game.UI.Windows.Menus;
using Game.Utilities;
using UnityEngine;

namespace Game.UI.Windows.Tabs
{
    public class TabsCreator : MonoBehaviour
    {
        private Creator<Tab> _tabsCreator;
        private List<TabsGroup<Tab>> _tabGroups;

        public void Initialize()
        {
            _tabsCreator = new Creator<Tab>(transform);
            _tabGroups = new List<TabsGroup<Tab>>();
        }

        public TabsGroup<Tab>[] CreateTabs(Tab tabPrefab, Menu[] menus)
        {
            var newTabGroups = new List<TabsGroup<Tab>>();

            for (int i = 0; i < menus.Length; i++)
            {
                var newTabGroup = CreateTab(tabPrefab, menus[i]);
                newTabGroups.Add(newTabGroup);
            }

            return newTabGroups.ToArray();
        }

        public TabsGroup<Tab>[] CreateTabs(Tab[] tabPrefabs, Menu[] menus)
        {
            var newTabGroups = new List<TabsGroup<Tab>>();

            for (int i = 0; i < menus.Length; i++)
            {
                var newTabGroup = CreateTab(tabPrefabs[i], menus[i]);
                newTabGroups.Add(newTabGroup);
            }

            return newTabGroups.ToArray();
        }

        public TabsGroup<Tab> CreateTab(Tab tabPrefab, Menu menu)
        {
            var tab = _tabsCreator.Create(tabPrefab);
            tab.Initialize(menu);
            Type tabMenuType = tab.Menu.GetType();

            foreach (var tabsGroup in _tabGroups)
            {
                if (tabsGroup.ElementsType == tabMenuType)
                {
                    tabsGroup.Add(tab);
                    return tabsGroup;
                }
            }

            var newGroup = new TabsGroup<Tab>(tabMenuType);
            newGroup.Add(tab);
            _tabGroups.Add(newGroup);
            return newGroup;
        }

        private void RemoveTab(Tab tab)
        {
            //_tabs.Remove(tab);
            // TODO: Дописать логику удаления из групп
            Destroy(tab);
        }
    }
}
