using Game.UI.Windows.Tabs;
using UnityEngine;

namespace Game.UI.Windows.Menus
{
    public class InventoryMenu : Menu
    {
        [Space]
        [SerializeField] private MenusCreator _menusCreator;
        [SerializeField] private TabsCreator _tabsCreator;
        [SerializeField] private TabSelector _tabSelector;
        [Space]
        [SerializeField] private Menu _slotsHolderPrefab;
        [SerializeField] private Tab _tabPrefab;
        [Space]
        [SerializeField] private string[] _slotsHoldersNames;

        public override void Initialize()
        {
            _menusCreator.Initialize();
            _tabsCreator.Initialize();

            var newMenus = _menusCreator.CreateMenus(_slotsHolderPrefab, _slotsHoldersNames.Length);

            for (int i = 0; i < newMenus.Length; i++)
            {
                newMenus[i].SetName(_slotsHoldersNames[i]);
                newMenus[i].Initialize();
            }

            var tabsGroups = _tabsCreator.CreateTabs(_tabPrefab, newMenus);

            _tabSelector.Initialize(tabsGroups);
        }
    }
}
