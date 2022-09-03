using UnityEngine;

namespace ObjectScripts
{
    public class BarrierCircuit : MonoBehaviour
    {
        [SerializeField] private bool switchOn;

        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;
        private SpriteRenderer spriteRenderer;

        private bool defaultSwitchOn;


        private void Awake()
        {
            this.defaultSwitchOn = this.switchOn;

            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }


        private void OnEnable()
        {
            this.switchOn = this.defaultSwitchOn;

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
