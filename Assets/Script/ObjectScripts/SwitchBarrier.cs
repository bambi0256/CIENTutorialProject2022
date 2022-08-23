using UnityEngine;

namespace ObjectScripts
{
    public class SwitchBarrier : MonoBehaviour
    {
        private bool switchOn;
        private int defaultLayer;

        // 0 is off state, 1 is on state
        [SerializeField] private Sprite[] sprites = new Sprite[2];
        private SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            setSprite();
            defaultLayer = gameObject.layer;
        }


        private void setSprite()
        {
            if (this.switchOn)
                this.spriteRenderer.sprite = this.sprites[1];
            else
                this.spriteRenderer.sprite = this.sprites[0];
        }


        private void toggleLayer()
        {
            // layer 8 is Obstruction
            if (this.switchOn)
                gameObject.layer = 8;
            else
                gameObject.layer = defaultLayer;

        }


        public void setSwitchOn(bool switchState)
        {
            this.switchOn = switchState;
            setSprite();
            toggleLayer();
        }
    }
}
