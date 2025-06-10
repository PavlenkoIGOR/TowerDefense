using System;
using TD;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Летательный аппарат 2Д.
    /// NOTE: важно учесть соотношение сил и скоростей чтобы физический движок не выдал пакость.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceShip : Destructible
    {
        /// <summary>
        /// Масса для автоматической установки у ригида.
        /// </summary>
        [Header("Space ship")]
        [SerializeField] private float m_Mass;

        /// <summary>
        /// Толкающая вперед сила.
        /// </summary>
        [SerializeField] private float m_Thrust;

        /// <summary>
        /// Вращающая сила.
        /// </summary>
        [SerializeField] private float m_Mobility;

        /// <summary>
        /// Максимальная линейная скорость.
        /// </summary>
        [SerializeField] private float m_MaxLinearVelocity;

        /// <summary>
        /// Максимальная вращательная скорость. В градусах/сек
        /// </summary>
        [SerializeField] private float m_MaxAngularVelocity;

        /// <summary>
        /// Сохраненная ссылка на ригид.
        /// </summary>
        private Rigidbody2D m_Rigid;
        public Rigidbody2D Rigid => m_Rigid;

        #region Public API

        /// <summary>
        /// Управление линейной тягой. -1.0 до +1.0
        /// </summary>
        public float ThrustControl { get; set; }

        /// <summary>
        /// Управление вращательной тягой. -1.0 до +1.0
        /// </summary>
        public float TorqueControl { get; set; }

        #endregion

        #region Unity events

        protected override void Start()
        {
            base.Start();

            m_Rigid = GetComponent<Rigidbody2D>();
            m_Rigid.mass = m_Mass;

            // единичная инерция для того чтобы упростить баланс кораблей.
            // либо неравномерные коллайдеры будут портить вращение
            // решается домножением торка на момент инерции
            m_Rigid.inertia = 1;

            //InitOffensive();
        }

        private void FixedUpdate()
        {
            UpdateRigidbody();
            //UpdateEnergyRegen();
        }

        #endregion

        /// <summary>
        /// Метод добавления сил кораблю для движения.
        /// </summary>
        private void UpdateRigidbody()
        {
            // прибавляем толкающую силу
            m_Rigid.AddForce(m_Thrust * ThrustControl * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);

            // линейное вязкое трение -V * C
            m_Rigid.AddForce(-m_Rigid.linearVelocity * (m_Thrust / m_MaxLinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

            // добавляем вращение
            m_Rigid.AddTorque(m_Mobility * TorqueControl * Time.fixedDeltaTime, ForceMode2D.Force);

            // вязкое вращательное трение
            m_Rigid.AddTorque(-m_Rigid.angularVelocity * (m_Mobility / m_MaxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        }



        /// <summary>
        /// Метод вычитания патронов из боезапаса корабля. Используется турелями.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>true если патроны были скушаны</returns>
        public bool DrawAmmo(int count)
        {
                return true;
        }

        /// <summary>
        /// Метод вычитания патронов из боезапаса корабля. Используется турелями.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>true если патроны были скушаны</returns>
        public bool DrawEnergy(int count)
        {
                return true;
        }

        
        /// <summary>
        /// Стреляем первичкой или вторичкой.
        /// </summary>
        /// <param name="mode"></param>
        public void Fire(TurretMode mode)
        {
            return;
        }

        public new void Use(EnemyAsset enemyAss)
        {
            m_MaxLinearVelocity = enemyAss.moveSpeed;
            base.Use(enemyAss);
        }
    }
}