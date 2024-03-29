using BallScripts;
using UnityEngine;

namespace TileScripts
{
    public class ToSlowTile : MonoBehaviour
    {
        private bool isSlow;
        //private SpriteRenderer spriteRenderer;
        //[SerializeField] private Sprite slowTileSprite;
        [SerializeField] private GameObject slowTileSpriteObject;
        private BallMove ballScript;

        // Start is called before the first frame update
        void Start()
        {
            //this.spriteRenderer = GetComponent<SpriteRenderer>();
        }


        public void setIsSlow()
        {
            this.isSlow = true;
            setSprite();
        }


        private void setSprite()
        {
            //this.spriteRenderer.sprite = slowTileSprite;

            this.slowTileSpriteObject.SetActive(true);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!this.isSlow) return;
            if (!other.gameObject.CompareTag("Ball")) return;
            
            this.ballScript =  other.gameObject.transform.parent.GetComponent<BallMove>();
            this.ballScript.BallSpeed /= 2.0f;
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (!this.isSlow) return;
            if (!other.gameObject.CompareTag("Ball")) return;
            
            this.ballScript.BallSpeed *= 2.0f;
        }
    }
}
