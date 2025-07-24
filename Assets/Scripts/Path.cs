using UnityEngine;
using SpaceShooter;

namespace TD
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private CircleArea _startArea;
        [SerializeField] private AIPointPatrol[] _points;
        public int length => _points.Length;

        public CircleArea startArea { get => _startArea; set => _startArea = value; }

        public AIPointPatrol this[int i] => _points[i];

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.black;
            foreach (var point in _points)
            {
                Gizmos.DrawWireSphere(point.transform.position, point.Radius);
            }
        }
    }
}
