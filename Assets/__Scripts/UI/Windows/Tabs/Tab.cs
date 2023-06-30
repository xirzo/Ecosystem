using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Game.UI.Windows.Menus;
using System;

namespace Game.UI.Windows.Tabs
{
    public class Tab : MonoBehaviour
    {
        public event Action OnClick;
        public Menu Menu { get; private set; }
        public bool IsSelected { get; private set; }

        [SerializeField] private TextMeshProUGUI _textField;
        [Space]
        [SerializeField] private Button _tabButton;
        [SerializeField] private Image _tabButtonImage;
        [Space]
        [SerializeField] private Color _selectedColor;

        private Color _defaultColor;

        public void Initialize(Menu menu)
        {
            Menu = menu;
            gameObject.name = $"Tab: ({Menu.Name})";
            _textField.text = Menu.Name;

            _defaultColor = _tabButtonImage.color;

            _tabButton.onClick.AddListener(() => OnClick?.Invoke());
        }

        private void OnDestroy()
        {
            _tabButton.onClick.RemoveListener(() => OnClick?.Invoke());
        }

        public void Enter()
        {
            IsSelected = true;
            _tabButtonImage.color = _selectedColor;
        }

        public void Exit()
        {
            _tabButtonImage.color = _defaultColor;
            IsSelected = false;
        }
    }
}
