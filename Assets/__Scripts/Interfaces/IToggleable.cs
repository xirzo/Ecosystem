using System;

namespace Game.Interfaces
{
    public interface IToggleable
    {
        public event Action<bool> OnToggled;
        public bool IsToggledByDefault { get; }
        public bool IsToggled { get; }
        public void Toggle();
    }
}
