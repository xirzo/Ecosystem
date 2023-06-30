using Game.Utilities;
using UnityEngine;

namespace Game.UI.Windows.Tabs
{
    public class TabSelector : MonoBehaviour
    {
        private Tab _currentTab;
        private TabsGroup<Tab>[] _tabsGroups;

        public void Initialize(TabsGroup<Tab>[] tabsGroup)
        {
            _tabsGroups = tabsGroup;

            foreach (var tabGroup in _tabsGroups)
            {
                foreach (var tab in tabGroup.Elements)
                {
                    tab.OnClick += () => Select(tab);
                }
            }

            Select(_tabsGroups[0].Elements[0]);
        }

        private void OnDestroy()
        {
            if (_tabsGroups != null)
            {
                foreach (var tabGroup in _tabsGroups)
                {
                    foreach (var tab in tabGroup.Elements)
                    {
                        tab.OnClick += () => Select(tab);
                    }
                }
            }
        }

        public void Select(Tab tabToSelect)
        {
            if (_currentTab != null)
            {
                Deselect(_currentTab);
            }

            _currentTab = tabToSelect;
            _currentTab.Menu.Show();
            _currentTab.Enter();
        }

        private void Deselect(Tab tabToDeselect)
        {
            tabToDeselect.Menu.Hide();
            tabToDeselect.Exit();
        }
    }
}
