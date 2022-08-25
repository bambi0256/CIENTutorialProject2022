using UnityEngine;

namespace ObjectScripts
{
    public class DurationChangeSprite : MonoBehaviour
    {
        [SerializeField] private float durationTime;
        [SerializeField] private float firstFlashTime;
        [SerializeField] private float secondFlashTime;
        private float durationDeltaTime;
        private float firstFlashCycleTime;
        private float secondFlashCycleTime;
        private float firstFlashDeltaTime;
        private float secondFlashDeltaTime;
        [SerializeField] private Sprite defaultSprite;
        [SerializeField] private Sprite brightSprite;
        private SpriteRenderer spriteRenderer;
        private bool trigger;
        private bool isBright;

        // Start is called before the first frame update
        void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.firstFlashCycleTime = 0.25f;
            this.secondFlashCycleTime = 0.15f;
        }

        // Update is called once per frame
        void Update()
        {
            if (this.trigger)
            {
                this.durationDeltaTime += Time.deltaTime;

                if (this.durationDeltaTime > this.durationTime)
                {
                    this.trigger = false;
                    this.isBright = false;
                    toggleSprite();
                    this.durationDeltaTime = 0.0f;
                    this.secondFlashDeltaTime = 0.0f;
                    this.firstFlashDeltaTime = 0.0f;
                }
                else if (this.durationDeltaTime > (this.durationTime - this.secondFlashTime))
                {
                    this.secondFlashDeltaTime += Time.deltaTime;

                    if (!(this.secondFlashDeltaTime > secondFlashCycleTime)) return;

                    toggleSprite();
                    this.secondFlashDeltaTime = 0.0f;
                }
                else if (this.durationDeltaTime > (this.durationTime - this.firstFlashTime))
                {
                    this.firstFlashDeltaTime += Time.deltaTime;

                    if (!(this.firstFlashDeltaTime > firstFlashCycleTime)) return;

                    toggleSprite();
                    this.firstFlashDeltaTime = 0.0f;
                }
            }
        }


        public void setTrigger()
        {
            this.trigger = true;
            this.isBright = true;
            toggleSprite();
        }


        private void toggleSprite()
        {
            if (this.isBright)
            {
                this.spriteRenderer.sprite = this.brightSprite;
                this.isBright = false;
            }
            else
            {
                this.spriteRenderer.sprite = this.defaultSprite;
                this.isBright = true;
            }
        }
    }
}
