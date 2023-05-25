
using System;

namespace Game.Commands
{
    [Serializable]
    public abstract class Command : ICommand
    {
        public abstract event Action<ICommander> OnExecuted;
        public abstract event Action<ICommander> OnUndid;
        public abstract void Execute();
        public abstract void Undo();
    }
}
