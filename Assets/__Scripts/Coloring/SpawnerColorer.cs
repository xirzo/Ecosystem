using UnityEngine;

namespace Game.Coloring
{
    public class SpawnerColorer : Colorer
    {
        private void Awake()
        {
            SetRandomColor();
        }
    }
}
