using SpaceShooter;
using UnityEngine;

namespace TD
{
    public class TD_Projectile : Projectile
    {
        public enum DamageType
        {
            Base,
            Magic
        }

        [SerializeField] private DamageType _damageType;

        protected override void OnHit(RaycastHit2D hit)
        {
            var enemy = hit.collider.transform.root.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDmg(m_Damage, _damageType);
            }
        }
    }
}