using System.Collections.Generic;
using UnityEngine;

namespace Game.Commands
{
    public class MoveCommander : Commander
    {
        private void Move()
        {
            MoveCommand move = new MoveCommand(this, transform, transform.forward, 2);

            Execute(move);
        }

        private void Unmove()
        {
            Undo();
        }
    }
}
