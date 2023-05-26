using Game.Interaction;
using UnityEditor;
using UnityEngine;

namespace Game.Editors
{
    [CustomEditor(typeof(RadiusInteractor))]
    public class RadiusInteractorEditor : Editor
    {
        private void OnSceneGUI()
        {
            RadiusInteractor interactor = (RadiusInteractor)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(interactor.Self.transform.position, Vector3.up, Vector3.forward, 360, interactor.InteractionRadius);

            if (Application.isPlaying == true)
            {

                if (interactor.InteractablesInRadius.Count > 0)
                {
                    Handles.color = Color.white;

                    foreach (var interactable in interactor.InteractablesInRadius)
                    {
                        Handles.DrawLine(interactor.Self.transform.position, interactable.Self.transform.position);
                    }

                    if (interactor.ClosesetInteractableInRadius != null)
                    {
                        Handles.color = Color.green;
                        Handles.DrawLine(interactor.Self.transform.position, interactor.ClosesetInteractableInRadius.Self.transform.position);
                    }
                }
            }
        }
    }
}
