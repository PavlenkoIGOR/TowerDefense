using UnityEngine;
using SpaceShooter;

namespace TD
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private AIPointPatrol[] _points;
        public int length => _points.Length;

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
