using UnityEngine;

namespace Script.ObjectScripts
{
    public class CannonballController : MonoBehaviour
    {
        // [SerializeField] private float mapWidth;
        // [SerializeField] private float mapHeight;
        [SerializeField] private float tileLength = 1.0f;
        private float speed;
        private bool isFirstTurret;


        private void Start()
        {
            this.speed = 1.0f;
            this.isFirstTurret = true;
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
            if (other.gameObject.CompareTag("Anchor") || other.gameObject.CompareTag("Ball"))
            {
                Destroy(gameObject);
            }
        }


        private void OnTriggerStay2D(Collider2D other)
        {
            if (isFirstTurret && other.gameObject.CompareTag("Turret")) return;

            if (other.gameObject.CompareTag("Hole")) return;

            // layer 8 is obstruction
            if (other.gameObject.layer == 8)
            {
                Destroy(gameObject);
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Turret"))
                this.isFirstTurret = false;
        }
    }
}
