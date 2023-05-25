using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Commands
{
    public class Commander : MonoBehaviour, ICommander
    {
        public event Action<ICommand> OnCommandExecuted;
        public event Action<ICommand> OnCommandUndid;
        protected Stack<ICommand> Commands => _commands;

        private Stack<ICommand> _commands = new Stack<ICommand>();

        public void Execute(ICommand command)
        {
            Add(command);
            command.Execute();
            OnCommandExecuted?.Invoke(command);

            //Debug.Log($"{command} was executed!"); 
        }

        public void Undo()
        {
            if (_commands.Count > 0 )
            {
                ICommand command = Remove();
                command.Undo();
                OnCommandUndid?.Invoke(command);

                //Debug.Log($"{command} was undid!");

                return;
            }

            throw new Exception($"Commander Stack doesn`t contain any commands!");
        }

        private void Add(ICommand command)
        {
            _commands.Push(command);
        }

        private ICommand Remove()
        {
            return _commands.Pop();
        }
    }
}
