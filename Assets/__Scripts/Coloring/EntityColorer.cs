using UnityEngine;

namespace Game.Coloring
{
    public class EntityColorer : Colorer
    {
        private void Start()
        {
            if (Color.Equals(Color.clear))
            {
                SetRandomColor();
            }
        }
    }
}
