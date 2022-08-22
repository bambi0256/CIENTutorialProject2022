using UnityEngine;

namespace ObjectScripts
{
    public class Circuit : MonoBehaviour
    {
        private bool switchOn;

        // 0 is off state, 1 is on state
        [SerializeField] private Sprite[] sprites = new Sprite[2];
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
                this.spriteRenderer.sprite = this.sprites[1];
            else
                this.spriteRenderer.sprite = this.sprites[0];
        }


        public void setSwitchOn(bool switchState)
        {
            this.switchOn = switchState;
            setSprite();
        }
    }
}
