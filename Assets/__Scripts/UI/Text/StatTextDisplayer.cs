using Game.Stats;
using UnityEngine;

namespace Game.UI
{
    public class StatTextDisplayer : TextDisplayer
    {
        [SerializeField] private Stat _entityStat;

        protected override void Awake()
        {
            base.Awake();

            _entityStat.OnStatChanged += UpdateStatText;
        }

        private void OnDestroy()
        {
            _entityStat.OnStatChanged -= UpdateStatText;
        }
        protected override void SetText(float amount)
        {
            TextField.text = Mathf.Round(amount).ToString();
        }

        private void UpdateStatText(float stat)
        {
            SetText(stat);
        }
    }
}
