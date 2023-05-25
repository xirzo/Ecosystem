using TMPro;
using UnityEngine;

namespace Game.UI
{
    public abstract class TextDisplayer : MonoBehaviour
    {
        protected TextMeshProUGUI TextField => _textField;

        private TextMeshProUGUI _textField;

        protected virtual void Awake()
        {
            TryGetComponent(out _textField);
        }

        protected virtual void SetText(float amount)
        {
            _textField.text = amount.ToString();
        }

        protected virtual void SetText(bool condition)
        {
            _textField.text = condition.ToString();
        }

        protected virtual void SetText(string text)
        {
            _textField.text = text;
        }
    }
}
