using System.Collections;
using Game.Interaction;
using Game.Orientations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Game.UI
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField] private PlayerCamera _camera;
        [Space]
        [SerializeField, Min(0)] private float _sizeMultpilier = 1.25f;

        private Vector3 _startScale;

        private void Awake()
        {
            _startScale = transform.localScale;
        }

        private void Update()
        {
            HandleSizing();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void HandleSizing()
        {
            if (_camera.TryToGetForwardCollider(out Collider collider) && collider.attachedRigidbody != null)
            {
                if (collider.attachedRigidbody.TryGetComponent(out InteractableBehavior target))
                {
                    if (transform.localScale != transform.localScale * _sizeMultpilier)
                    {
                        transform.localScale *= _sizeMultpilier;
                    }

                    transform.localScale = _startScale * _sizeMultpilier;
                    return;
                }
            }

            if (transform.localScale != transform.localScale * _sizeMultpilier)
            {
                transform.localScale /= _sizeMultpilier;
            }

            transform.localScale = _startScale;
            return;
        }
    }
}
