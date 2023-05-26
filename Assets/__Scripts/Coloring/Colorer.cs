using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Coloring
{
    public abstract class Colorer : MonoBehaviour
    {
        public event Action<Color> ColorChanged;
        public Color Color { get; private set; }

        [SerializeField] private Renderer[] _renderers;

        public void SetRandomColor()
        {
            Color randomColor = Random.ColorHSV();
            SetColor(randomColor);
        }

        public void SetColor(Color color)
        {
            Color = color;
            ChangeMaterialColor();

            ColorChanged?.Invoke(color);
        }

        private void ChangeMaterialColor()
        {
            foreach (var renderer in _renderers)
            {
                renderer.material.color = Color;
            }
        }
    }
}
