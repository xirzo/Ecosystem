using Game.Targeting;
using UnityEditor;
using UnityEngine;

namespace Game.Editors
{
    [CustomEditor(typeof(Targeter))]
    public class TargeterEditor : Editor
    {
        private void OnSceneGUI()
        {
            Targeter targeter = (Targeter)target;
            Handles.color = Color.red;
            Handles.DrawWireArc(targeter.transform.position, Vector3.up, Vector3.forward, 360, targeter.TargetingRange);

            if (targeter.Target != null)
            {
                Handles.color = Color.green;
                Handles.DrawLine(targeter.transform.position, targeter.Target.transform.position);
            }
        }
    }
}
