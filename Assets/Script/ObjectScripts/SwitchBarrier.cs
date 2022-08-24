using UnityEngine;

namespace ObjectScripts
{
    public class SwitchBarrier : MonoBehaviour
    {
        [SerializeField] private bool switchOn;
        private int defaultLayer;

        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;
        private SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            defaultLayer = gameObject.layer;
            setSprite();
        }


        private void setSprite()
        {
            if (this.switchOn)
                this.spriteRenderer.sprite = this.onSprite;
            else
                this.spriteRenderer.sprite = this.offSprite;
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
