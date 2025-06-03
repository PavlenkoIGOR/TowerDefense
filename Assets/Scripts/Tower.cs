using SpaceShooter;
using UnityEngine;

namespace TD
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float m_Radius;


        private Turret[] _turrets;
        private Destructible _target = null;
        private static readonly Color GizmoColor = new Color(1, 0, 0, 0.3f);

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = GizmoColor;

            Gizmos.DrawWireSphere(transform.position, m_Radius);
        }
#endif
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _turrets = GetComponentsInChildren<Turret>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_target)
            {
                if (Vector2.Distance(_target.transform.position, transform.position) <= m_Radius)
                {
                    foreach (var turret in _turrets)
                    {
                        turret.Fire();
                    }
                }
                else
                {
                    _target = null;
                }
            }
            else
            {
                var enter = Physics2D.OverlapCircle(transform.position, m_Radius);
                if (enter)
                {
                    _target = enter.transform.GetComponent<Destructible>();

                }
            }

        }
    }
}
