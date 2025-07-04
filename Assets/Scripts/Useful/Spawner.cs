﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TD;

namespace SpaceShooter
{

    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected Path _path;
        ///// <summary>
        ///// Ссылки на то что спавнить.
        ///// </summary>
        //[SerializeField] private Entity[] m_EntityPrefabs;
        protected abstract GameObject GenerateSpawnEntity();

       // [SerializeField] private EnemyAsset[] _enemyAsset;
        /// <summary>
        /// Зона спавна.
        /// </summary>
        [SerializeField] private CircleArea m_Area;

        /// <summary>
        /// Режим спавна.
        /// </summary>
        public enum SpawnMode
        {
            /// <summary>
            /// На методе Start()
            /// </summary>
            Start,

            /// <summary>
            /// Периодически используя время m_RespawnTime
            /// </summary>
            Loop
        }

        [SerializeField] private SpawnMode m_SpawnMode;

        /// <summary>
        /// Кол-во объектов которые будут разом заспавнены.
        /// </summary>
        [SerializeField] private int m_NumSpawns;

        /// <summary>
        /// Время респавна. Здесь важно заметить что респавн таймер должен быть больше времени жизни объектов.
        /// </summary>
        [SerializeField] private float m_RespawnTime;

        private float m_Timer;

        private void Start()
        {
            if(m_SpawnMode == SpawnMode.Start)
            {
                SpawnEntities();
            }
        }

        private void Update()
        {
            if (m_Timer > 0)
                m_Timer -= Time.deltaTime;

            if(m_SpawnMode == SpawnMode.Loop && m_Timer <= 0)
            {
                SpawnEntities();
                m_Timer = m_RespawnTime;
            }
        }

        private void SpawnEntities()
        {
            for(int i = 0; i < m_NumSpawns; i++)
            {
                //var prefabToSpawn = m_EntityPrefabs[UnityEngine.Random.Range(0, m_EntityPrefabs.Length)];
                //var e = Instantiate(prefabToSpawn);
                var e = GenerateSpawnEntity();
                e.transform.position = m_Area.RandomInsideZone;

                //if (e.TryGetComponent<TD_PatrolController>(out var ai))
                //{
                //    ai.SetPath(_path);
                //}
                //if (e.TryGetComponent<Enemy>(out var enemy))
                //{
                //    enemy.Use(_enemyAsset[Random.Range(0, 3)]);
                //}
            }
        }
    }
}