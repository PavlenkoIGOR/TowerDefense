using UnityEngine;

namespace TD
{
    [CreateAssetMenu]
    public sealed class EnemyAsset : ScriptableObject
    {
        [Header("Visualize")]
        public Color color = Color.white;
        public Vector2 spriteScale = new Vector2(3,3);
        public RuntimeAnimatorController controller;

        [Header("GameParams")]
        public float moveSpeed = 1;
        public int hp  = 1;
        public int score = 1;
        public float radius = 0.14f;
    }
}