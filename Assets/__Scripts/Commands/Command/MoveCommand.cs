using System;
using UnityEngine;
using UnityEngine.Analytics;

namespace Game.Commands
{
    public class MoveCommand : Command
    {
        public override event Action<ICommander> OnExecuted;
        public override event Action<ICommander> OnUndid;

        private ICommander _sender;
        private Transform _transform;
        private Vector3 _direction;
        private float _distance;

        public MoveCommand(ICommander sender, Transform transform, Vector3 direction, float distance = 5f) 
        {
            _sender = sender;
            _transform = transform;
            _direction = direction;
            _distance = distance;
        }


        public override void Execute()
        {
            _transform.position += _direction * _distance;
            OnExecuted?.Invoke(_sender);
        }

        public override void Undo()
        {
            _transform.position -= _direction * _distance;
        }
    }
}
