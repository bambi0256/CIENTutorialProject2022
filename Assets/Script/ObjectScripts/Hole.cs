using BallScripts;
using UnityEngine;

namespace ObjectScripts
{
    public class Hole : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        private SpriteRenderer spriteRenderer;

        private AroundHole aroundHole;

        // Start is called before the first frame update
        private void Start()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.aroundHole = GetComponentInChildren<AroundHole>();
        }


        public void holeClose()
        {
            setSprite();
            this.aroundHole.setIsClose();
        }


        private void setSprite()
        {
            this.spriteRenderer.sprite = this.sprite;
        }
    }
}
