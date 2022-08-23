using UnityEngine;

namespace ObjectScripts
{
    public class CannonballController : MonoBehaviour
    {
        // [SerializeField] private float mapWidth;
        // [SerializeField] private float mapHeight;
        [SerializeField] private float tileLength = 1.0f;
        private float speed;
        private bool isFirstTurret;

        // 1 = up, 2 = right, 3 = down, 4 = left
        [SerializeField]private Vector3 cannonballDir;


        private void Start()
        {
            this.speed = 1.0f;
            this.isFirstTurret = true;

            if (transform.rotation == Quaternion.Euler(0, 0, 0))
                this.cannonballDir = Vector3.up;
            else if (transform.rotation == Quaternion.Euler(0, 0, 180))
                this.cannonballDir = Vector3.down;
            else if (transform.rotation == Quaternion.Euler(0, 0, 90))
                this.cannonballDir = Vector3.left;
            else if (transform.rotation == Quaternion.Euler(0, 0, -90))
                this.cannonballDir = Vector3.right;

            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(this.cannonballDir * this.tileLength * this.speed / 2.0f);

            /*
            AudioManager.instance.PlaySFX("ShootingBullet");
            */
        }




        private void Update()
        {
            transform.Translate(this.cannonballDir * this.tileLength * this.speed * Time.deltaTime);
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
