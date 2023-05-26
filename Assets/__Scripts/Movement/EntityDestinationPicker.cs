using Game.Coloring;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Movement
{
    public class EntityDestinationPicker : MonoBehaviour
    {
        public Vector3 Point => _point;

        [SerializeField, Min(0)] private float _maxDistanceToPoint = 30f;

        private Colorer _colorer;
        private NavMeshTriangulation _navMeshData;

        private Vector3 _point;

        private void Awake()
        {
            TryGetComponent(out _colorer); 

            _navMeshData = NavMesh.CalculateTriangulation();
        }

        public void SetPointRandomDestinationInDistance()
        {
            Vector3 point = GetRandomDestination();
            float distance = Vector3.Distance(transform.position, point);

            while(distance > _maxDistanceToPoint)
            {
                point = GetRandomDestination();
                distance = Vector3.Distance(transform.position, point);
            }

            _point = point;
        }

        private Vector3 GetRandomDestination()
        {
            int firstIndiceOfRandomTriangle = Random.Range(0, _navMeshData.indices.Length - 3);

            Vector3 point = Vector3.Lerp
                (_navMeshData.vertices[_navMeshData.indices[firstIndiceOfRandomTriangle]],
                _navMeshData.vertices[_navMeshData.indices[firstIndiceOfRandomTriangle + 1]],
                Random.value);

            Vector3.Lerp(point, _navMeshData.vertices[_navMeshData.indices[firstIndiceOfRandomTriangle + 2]], Random.value);

            return point;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying == true)
            {
                Gizmos.color = _colorer.Color;
                Gizmos.DrawCube(_point, new Vector3(0.5f, 2, 0.5f));
            }
        }
    }
}
