using UnityEngine;

namespace ObjectScripts
{
    public class Circuit : MonoBehaviour
    {
        [SerializeField] private bool switchOn;

        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;
        private SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            setSprite();
        }


        private void setSprite()
        {
            if (this.switchOn)
                this.spriteRenderer.sprite = this.onSprite;
            else
                this.spriteRenderer.sprite = this.offSprite;
        }


        public void setSwitchOn(bool switchState)
        {
            this.switchOn = switchState;
            setSprite();
        }
    }
}
