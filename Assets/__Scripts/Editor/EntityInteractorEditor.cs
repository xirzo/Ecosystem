using Game.Interaction;
using UnityEditor;
using UnityEngine;

namespace Game.Editors
{
    [CustomEditor(typeof(EntityInteractor))]
    public class EntityInteractorEditor : Editor
    {
        private void OnSceneGUI()
        {
            EntityInteractor interactor = (EntityInteractor)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(interactor.transform.position, Vector3.up, Vector3.forward, 360, interactor.InteractionRadius);

            if (Application.isPlaying == true)
            {

                if (interactor.AvailableInteractables.Count > 0)
                {
                    Handles.color = Color.white;

                    foreach (var interactable in interactor.AvailableInteractables)
                    {
                        Handles.DrawLine(interactor.transform.position, interactable.Self.transform.position);
                    }

                    if (interactor.ClosesetAvailableInteractable != null)
                    {
                        Handles.color = Color.green;
                        Handles.DrawLine(interactor.transform.position, interactor.ClosesetAvailableInteractable.Self.transform.position);
                    }
                }
            }
        }
    }
}
