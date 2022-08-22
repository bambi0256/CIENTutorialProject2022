using UnityEngine;

namespace ObjectScripts
{
    public class Switch : MonoBehaviour
    {
        [SerializeField] private bool switchOn;
        [SerializeField] private GameObject[] switchBarrierList = new GameObject[1];
        private SwitchBarrier[] barrierScriptList;

        // 0 is off state, 1 is on state
        [SerializeField] private Sprite[] sprites = new Sprite[2];
        private SpriteRenderer spriteRenderer;


        private void Start()
        {
            this.barrierScriptList = new SwitchBarrier[switchBarrierList.Length];

            for (int i = 0; i < switchBarrierList.Length; i++)
            {
                this.barrierScriptList[i] = switchBarrierList[i].GetComponent<SwitchBarrier>();
                this.barrierScriptList[i].setSwitchOn(this.switchOn);
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

            for (int i = 0; i < switchBarrierList.Length; i++)
            {
                this.barrierScriptList[i] = switchBarrierList[i].GetComponent<SwitchBarrier>();
                this.barrierScriptList[i].setSwitchOn(this.switchOn);
            }
        }


        private void setSprite()
        {
            if (this.switchOn)
                this.spriteRenderer.sprite = this.sprites[1];
            else
                this.spriteRenderer.sprite = this.sprites[0];
        }
    }
}
