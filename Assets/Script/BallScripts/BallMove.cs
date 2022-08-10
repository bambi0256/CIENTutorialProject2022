using UnityEngine;

namespace Script.BallScripts
{
    public class BallMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        
        public static int BallDir;
        // 0 = stop, 1 = up, 2 = right, 3 = down, 4 = left
        public static float BallSpeed;

        private readonly Vector2 Up = new Vector2(0, 1);
        private readonly Vector2 Right = new Vector2(1, 0);
        private readonly Vector2 Down = new Vector2(0, -1);
        private readonly Vector2 Left = new Vector2(-1, 0);

        private bool cannonballHit;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            BallSpeed = 10;
        }

        private void FixedUpdate()
        {
            Move();
            CheckDeath();
        }

        private void Move()
        {
            _rigidbody2D.velocity = BallDir switch
            {
                1 => Up * (Time.deltaTime * BallSpeed),
                2 => Right * (Time.deltaTime * BallSpeed),
                3 => Left * (Time.deltaTime * BallSpeed),
                4 => Down * (Time.deltaTime * BallSpeed),
                _ => _rigidbody2D.velocity
            };
        }

        private void CheckDeath()
        {
            // if ball is hit by cannonball, game over
            if (this.cannonballHit)
            {
                Debug.Log("Game Over");
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Cannonball"))
            {
                this.cannonballHit = true;
            }
            else if (other.gameObject.CompareTag("InPortal"))
            {
                Debug.Log("Portal move");
            }
        }
    }
}
