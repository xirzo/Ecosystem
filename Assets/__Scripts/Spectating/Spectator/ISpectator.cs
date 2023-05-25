using System;

namespace Game.Spectating
{
    public interface ISpectator
    {
        public event Action<bool> OnIsSpectatingChanged;
        public bool IsSpectating { get; }
        public void Spectate(ISpectatorable spectatorable);
        public void Unspectate();
    }
}
