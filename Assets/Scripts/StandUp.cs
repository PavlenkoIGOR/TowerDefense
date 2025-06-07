using System.ComponentModel;
using UnityEngine;

namespace TD
{
    public class StandUp : MonoBehaviour
    {
        Rigidbody2D rb;
        [SerializeField] private SpriteRenderer rbSprite;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = transform.root.GetComponent<Rigidbody2D>();
            
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.up = Vector2.up;
            var xMotion = rb.linearVelocity.x;
            if (xMotion > 0.01f)
            {
                rbSprite.flipX = false;
            }
            else if(xMotion < 0.01f)
            {
                rbSprite.flipX=true;
            }
        }
    }
}
