
using System;

namespace Game.Commands
{
    public interface ICommand
    {
        public event Action<ICommander> OnExecuted;
        public event Action<ICommander> OnUndid;
        public void Execute();
        public void Undo();
    }
}
