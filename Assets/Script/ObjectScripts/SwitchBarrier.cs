using UnityEngine;

namespace Script.ObjectScripts
{
    public class SwitchBarrier : MonoBehaviour
    {
        public bool switchOn;
        private bool switchPreState;

        // 0 is off state, 1 is on state
        [SerializeField] private Sprite[] sprites = new Sprite[2];
        private SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            setSprite();
        }

        // Update is called once per frame
        void Update()
        {
            if (this.switchPreState ^ this.switchOn)
            {
                this.switchPreState = this.switchOn;

                setSprite();
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
