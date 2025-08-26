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

        public void Use(TowerAsset towerAsset)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = towerAsset.sprite;
            _turrets = GetComponentsInChildren<Turret>();
            if (_turrets != null)
            {
                foreach (var turret in _turrets)
                {
                    turret.AssignLoadout(towerAsset.turretProperties);
                }
            }
            var buildSite = GetComponentInChildren<BuildSite>();
            buildSite.SetBuildableTowers(towerAsset._upgradesTo);
        }

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
            //print($"{_turrets.Length}");
        }

        // Update is called once per frame
        void Update()
        {
            if (_target)
            {
                var targetVector = _target.transform.position - transform.position;
                if (targetVector.magnitude <= m_Radius)
                {
                    foreach (var turret in _turrets)
                    {
                        turret.transform.up = targetVector;
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
                    _target = enter.transform.root.GetComponent<Destructible>();

                }
            }

        }
    }
}
