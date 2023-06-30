using System;
using Game.Interfaces;
using UnityEngine;

namespace Game.UI.Windows.Menus
{
    public abstract class Menu : MonoBehaviour, IToggleable
    {
        public event Action<bool> OnToggled;
        public bool IsToggled => _isToggled;
        public bool IsToggledByDefault => _isToggledByDefault;
        public string Name => _name;

        [SerializeField] private bool _isToggledByDefault = true;
        [Space]
        [SerializeField] private string _name;

        private bool _isToggled;

        public virtual void Initialize()
        {
            if (_isToggledByDefault == false)
            {
                Toggle();
            }
        }

        public void SetName(string name)
        {
            _name = name;
            gameObject.name = $"Menu: ({name})";
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Toggle()
        {
            _isToggled = !_isToggled;
            OnToggled?.Invoke(_isToggled);

            if (_isToggled == true)
            {
                Show();
                return;
            }

            Hide();
        }
    }
}
