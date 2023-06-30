using System.Collections.Generic;
using Game.Utilities;
using UnityEngine;

namespace Game.UI.Windows.Menus
{
    public class MenusCreator : MonoBehaviour
    {
        private Creator<Menu> _menusCreator;
        private List<Menu> _menus;

        public void Initialize()
        {
            _menusCreator = new Creator<Menu>(transform);
            _menus = new List<Menu>();
        }

        public Menu[] CreateMenus(Menu prefab, int count)
        {
            var newMenus = new Menu[count];

            for (int i = 0; i < count; i++)
            {
                var newMenu = CreateMenu(prefab);
                newMenus[i] = newMenu;
            }

            return newMenus;
        }

        public Menu[] CreateMenus(Menu[] prefabs)
        {
            var newMenus = new Menu[prefabs.Length];

            for (int i = 0; i < prefabs.Length; i++)
            {
                var newMenu = CreateMenu(prefabs[i]);
                newMenus[i] = newMenu;
            }

            return newMenus;
        }

        public Menu CreateMenu(Menu prefab)
        {
            var newMenu = _menusCreator.Create(prefab);
            newMenu.Hide();
            _menus.Add(newMenu);
            return newMenu;
        }

        private void RemoveMenu(Menu menu)
        {
            _menus.Remove(menu);
            Destroy(menu);
        }
    }
}
