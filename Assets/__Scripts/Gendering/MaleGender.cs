using UnityEngine;

namespace Game.Gendering
{
    public class MaleGender : Gender
    {
        private readonly string _name = "Male";

        public MaleGender()
        {
            Name = _name;
        }
    }
}
