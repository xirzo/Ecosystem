using Game.Entities;
using Game.Gendering;
using UnityEngine;

namespace Game.UI
{
    public class GenderTextDisplayer : TextDisplayer
    {
        [SerializeField] private Entity _entity;

        protected override void Awake()
        {
            base.Awake();

            _entity.OnGenderSet += gender => UpdateStateText(gender);
        }

        private void OnDestroy()
        {
            _entity.OnGenderSet -= gender => UpdateStateText(gender);
        }

        private void UpdateStateText(Gender gender)
        {
            SetText(gender.Name);
        }
    }
}
