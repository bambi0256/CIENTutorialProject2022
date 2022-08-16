using BallScripts;
using UnityEngine;

namespace Script.ObjectScripts
{
    public class Hole : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        private SpriteRenderer spriteRenderer;
        private bool isClose;

        // Start is called before the first frame update
        private void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }


        public void holeClose()
        {
            setSprite();
            this.isClose = true;            
        }


        private void setSprite()
        {
            this.spriteRenderer.sprite = this.sprite;
        }


        public bool getIsClose()
        {
            return this.isClose;
        }
    }
}
