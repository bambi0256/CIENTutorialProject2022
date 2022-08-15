using UnityEngine;

namespace Script.ObjectScripts
{
    public class Hole : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        private SpriteRenderer spriteRenderer;
        private bool isClose;

        private bool ballEnter;
        private float ballStayTime;
        private float ballStayDeltaTime;

        // Start is called before the first frame update
        private void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.ballStayTime = 5.0f;
        }


        private void Update()
        {
            if ((!this.isClose) && this.ballEnter)
            {
                ballStayDeltaTime = Time.deltaTime;

                if (!(ballStayDeltaTime > ballStayTime)) return;

                
            }
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


        public void setBallEnter()
        {
            this.ballEnter = true;
        }
    }
}
