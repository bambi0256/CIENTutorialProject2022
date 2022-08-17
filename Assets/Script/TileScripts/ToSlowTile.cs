using BallScripts;
using UnityEngine;

namespace TileScripts
{
    public class ToSlowTile : MonoBehaviour
    {
        private bool isSlow;
        private SpriteRenderer spriteRenderer;
        private BallMove ballScript;

        // Start is called before the first frame update
        void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }


        public void setIsSlow()
        {
            this.isSlow = true;
            setSprite();
        }


        private void setSprite()
        {
            // change the sprite or color
            return;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            
            other.gameObject.transform.parent.GetComponent<BallMove>().BallSpeed /= 2.0f;
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            
            other.gameObject.transform.parent.GetComponent<BallMove>().BallSpeed *= 2.0f;
        }
    }
}
