﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Определение эпизода как набора уровней. Уровни идут последовательно.
    /// </summary>
    [CreateAssetMenu]
    public class Episode : ScriptableObject
    {
        /// <summary>
        /// Название эпизода.
        /// </summary>
        [SerializeField] private string m_EpisodeName;
        public string EpisodeName => m_EpisodeName;

        /// <summary>
        /// Список названий сцен. Последовательно.
        /// </summary>
        [Tooltip("Здесь указать имя сцены как оно есть")]
        [SerializeField] private string[] m_Levels;
        public string[] Levels => m_Levels;

        /// <summary>
        /// Превьюшка эпизода. Квадратная картинка например.
        /// </summary>
        [SerializeField] private Sprite m_PreviewImage;
        public Sprite PreviewImage => m_PreviewImage;
    }
}