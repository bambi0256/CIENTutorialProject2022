using UnityEngine;

namespace Script.ObjectScripts
{
    public class SwitchBarrier : MonoBehaviour
    {
        public bool switchOn;
        private bool switchPreState;
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

        // Update is called once per frame
        void Update()
        {
            if (this.switchPreState ^ this.switchOn)
            {
                this.switchPreState = this.switchOn;

                setSprite();
                toggleLayer();
            }
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
            if (gameObject.layer == defaultLayer)
                gameObject.layer = 8;
            else if (gameObject.layer == 8)
                gameObject.layer = defaultLayer;

        }
    }
}
