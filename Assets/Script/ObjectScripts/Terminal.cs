using UnityEngine;

namespace ObjectScripts
{
    public class Terminal : MonoBehaviour
    {
        // 1 is up, 2 is down, 3 is left, 4 is right
        private int terminalDir;
        private int circuitDir;

        // 0 is UtoD, 1 is LtoR, 2 is UtoL, 3 is LtoD, 4 is DtoR, 5 is RtoU
        [SerializeField] private Sprite[] sprites = new Sprite[6];
        private SpriteRenderer spriteRenderer;
        
        // Start is called before the first frame update
        private void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }


        public void terminalCollision(int direction)
        {
            this.terminalDir = direction;

            //Debug.Log("ter");

            if (circuitDir > 0)
            {
                changeSprite(terminalDir * circuitDir);
                //Debug.Log("two");
            }
        }


        public void circuitCollision(int direction)
        {
            this.circuitDir = direction;

            //Debug.Log("cir");

            if (terminalDir > 0)
                changeSprite(terminalDir * circuitDir);
        }


        private void changeSprite(int key)
        {
            switch (key)
            {
                case 2:
                    this.spriteRenderer.sprite = this.sprites[0];
                    break;
                case 3:
                    this.spriteRenderer.sprite = this.sprites[2];
                    break;
                case 4:
                    this.spriteRenderer.sprite = this.sprites[5];
                    break;
                case 6:
                    this.spriteRenderer.sprite = this.sprites[3];
                    break;
                case 8:
                    this.spriteRenderer.sprite = this.sprites[4];
                    break;
                case 12:
                    this.spriteRenderer.sprite = this.sprites[1];
                    break;
            }
        }
    }
}
