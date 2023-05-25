using System;

namespace Game.Commands
{
    public interface ICommander
    {
        public event Action<ICommand> OnCommandExecuted;
        public event Action<ICommand> OnCommandUndid;
        public void Execute(ICommand command);
        public void Undo();
    }
}
