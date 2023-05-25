using Game.Entities;
using UnityEngine;

namespace Game.UI
{
    public class GenderTextDisplayer : TextDisplayer
    {
        [SerializeField] private Entity _entity;

        protected override void Awake()
        {
            base.Awake();

            UpdateStateText();
        }

        private void UpdateStateText()
        {
            SetText(_entity.Gender.ToString());
        }
    }
}
