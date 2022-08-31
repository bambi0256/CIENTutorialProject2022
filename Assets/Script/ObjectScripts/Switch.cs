using UnityEngine;

namespace ObjectScripts
{
    public class Switch : MonoBehaviour
    {
        [SerializeField] private bool switchOn;
        [SerializeField] private GameObject[] switchBarrierList = new GameObject[1];
        private SwitchBarrier[] barrierScriptList;
        private int barrierCount;

        [SerializeField] private GameObject[] circuitList = new GameObject[1];
        private Circuit[] circuitScriptList;
        private int circuitCount;

        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;
        private SpriteRenderer spriteRenderer;


        private void Start()
        {
            this.barrierCount = switchBarrierList.Length;
            this.circuitCount = circuitList.Length;

            this.barrierScriptList = new SwitchBarrier[this.barrierCount];
            this.circuitScriptList = new Circuit[this.circuitCount];

            int i;

            for (i = 0; i < this.barrierCount; i++)
            {
                this.barrierScriptList[i] = switchBarrierList[i].GetComponent<SwitchBarrier>();
            }

            for (i = 0; i < this.circuitCount; i++)
            {
                this.circuitScriptList[i] = circuitList[i].GetComponent<Circuit>();
            }

            this.spriteRenderer = GetComponent<SpriteRenderer>();

            setSprite();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Anchor"))
            {
                switchToggle();
                setSprite();

                AudioManager.instance.PlaySFX("Switch");
            }
        }


        /*
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Anchor"))
            {
                switchToggle();
            }
        }
        */


        private void switchToggle()
        {
            this.switchOn = this.switchOn ^ true;

            int i;

            for (i = 0; i < this.barrierCount; i++)
            {
                this.barrierScriptList[i].setSwitchOn(this.switchOn);
            }

            for (i = 0; i < this.circuitCount; i++)
            {
                this.circuitScriptList[i].setSwitchOn(this.switchOn);
            }
        }


        private void setSprite()
        {
            if (this.switchOn)
                this.spriteRenderer.sprite = this.onSprite;
            else
                this.spriteRenderer.sprite = this.offSprite;
        }
    }
}
