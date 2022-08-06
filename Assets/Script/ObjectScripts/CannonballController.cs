using UnityEngine;

namespace Script.ObjectScripts
{
    public class CannonballController : MonoBehaviour
    {
        // [SerializeField] private float mapWidth;
        // [SerializeField] private float mapHeight;
        [SerializeField] private float tileLength = 1.0f;
        private float speed;


        private void Start()
        {
            this.speed = 1.0f;
        }


        private void Update()
        {
            transform.Translate(Vector3.up * this.tileLength * this.speed * Time.deltaTime);

            /*
            if (Mathf.Abs(transform.position.x) > this.mapWidth + 1 || Mathf.Abs(transform.position.y) > this.mapHeight + 1 )
            {
                Destroy(gameObject);
            }
            */
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Anchor"))
            {
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Ball"))
            {
                //Destroy the ball
            }
        }


        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Turret")) return;

            // layer 8 is obstruction
            if (other.gameObject.layer == 8)
            {
                Destroy(gameObject);
            }
        }
    }
}
