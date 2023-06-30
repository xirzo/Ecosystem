using System.Collections.Generic;
using Game.UI.Windows.Tabs;
using UnityEngine;

namespace Game.UI.Windows.Menus
{
    public class MasterMenu : Menu
    {
        [Space]
        [SerializeField] private MenusCreator _menusCreator;
        [SerializeField] private TabsCreator _tabsCreator;
        [SerializeField] private TabSelector _tabSelector;
        [Space]
        [SerializeField] private InventoryMenu[] _inventoriesPrefabs;
        [SerializeField] private Tab _tabPrefab;

        private List<Menu> _menusToCreatePrefabs;

        // * Point of enter

        private void Awake()
        {
            Initialize();
        }

        public override void Initialize()
        {
            _menusCreator.Initialize();
            _tabsCreator.Initialize();

            _menusToCreatePrefabs = new List<Menu>();

            _menusToCreatePrefabs.AddRange(_inventoriesPrefabs);

            var newMenus = _menusCreator.CreateMenus(_menusToCreatePrefabs.ToArray());
            var tabsGroups = _tabsCreator.CreateTabs(_tabPrefab, newMenus);

            foreach (var menu in newMenus)
            {
                menu.Initialize();
            }

            _tabSelector.Initialize(tabsGroups);
        }
    }
}
