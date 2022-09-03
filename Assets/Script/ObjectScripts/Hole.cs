using BallScripts;
using UnityEngine;

namespace ObjectScripts
{
    public class Hole : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        private Sprite defaultSprite;
        private SpriteRenderer spriteRenderer;

        private AroundHole aroundHole;


        private void Awake()
        {
            this.defaultSprite = this.sprite;
        }
        

        private void OnEnable()
        {
            this.spriteRenderer.sprite = this.defaultSprite;
        }

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
