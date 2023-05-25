using UnityEngine;

namespace Game.Coloring
{
    public class SpawnerColor : MonoBehaviour
    {
        public Color Color => _color;

        [SerializeField] private Renderer[] _renderers;

        private Color _color;

        private void Awake()
        {
            SetColor(GetRandomColor());
        }

        public void SetColor(Color color)
        {
            _color = color;
            ChangeMaterialColor();
        }

        public Color GetRandomColor()
        {
            return new Color(Random.value, Random.value, Random.value);
        }

        private void ChangeMaterialColor()
        {
            foreach (var renderer in _renderers)
            {
                renderer.material.color = _color;
            }
        }
    }
}
