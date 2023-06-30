using Game.ScriptableObjects;
using Game.Stats;
using UnityEngine;

namespace Game.Interaction
{
    [RequireComponent(typeof(Health))]
    public class EntityInteractable : InteractableBehaviour
    {
        public new EntityInteractableData Data => (EntityInteractableData)base.Data;

        [SerializeField] private Collider[] _collidersToChangeLayer;

        private readonly string _predatorInteractableLayerName = "Interactable";

        private Health _health;

        private void Awake()
        {
            TryGetComponent(out _health);

            _health.OnDied += OnDied;
        }

        private void OnDestroy()
        {
            _health.OnDied -= OnDied;
        }

        private void OnDied()
        {
            SetChildrenCollidersLayer();
        }

        private void SetChildrenCollidersLayer()
        {
            Collider[] children = _collidersToChangeLayer;

            foreach (var child in children)
            {
                child.gameObject.layer = LayerMask.NameToLayer(_predatorInteractableLayerName);
            }
        }

        //private Collider[] GetChildrenColliders()
        //{
        //    Transform[] children = new Transform[transform.childCount];
        //    Collider[] colliders = new Collider[transform.childCount];

        //    int index = 0;

        //    for (int i = 0; i < transform.childCount; i++)
        //    {
        //        children[i] = transform.GetChild(i);

        //        if (children[i].TryGetComponent(out Collider collider) && collider.isTrigger == false)
        //        {
        //            colliders[index] = collider;
        //            index++;
        //        }
        //    }

        //    return colliders;
        //}
    }
}