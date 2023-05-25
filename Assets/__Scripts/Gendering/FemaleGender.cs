using UnityEngine;

namespace Game.Gendering
{
    public class FemaleGender : Gender
    {
        private readonly string _name = "Female";

        public FemaleGender()
        {
            Name = _name;
        }
    }
}
