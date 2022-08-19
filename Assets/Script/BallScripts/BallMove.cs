using UnityEngine;

namespace BallScripts
{
    public class BallMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        public static int BallDir = 2;
        // 0 = stop, 1 = up, 2 = right, 3 = down, 4 = left
        public float BallSpeed;

        private readonly Vector2 Up = new Vector2(0, 1);
        private readonly Vector2 Right = new Vector2(1, 0);
        private readonly Vector2 Down = new Vector2(0, -1);
        private readonly Vector2 Left = new Vector2(-1, 0);

        private bool cannonballHit;
        private bool blockHit;
        private bool isIntoHole;
        private bool onTile;
        private float ballStayTime;
        private float ballStayDeltaTime;

        private bool isGameOver;
        private bool isClear;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            BallSpeed = 10;
            BallDir = 0;

            this.ballStayTime = 5.0f;
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
            // if ball get collision with wall, game over
            if (this.blockHit)
            {
                Debug.Log("Game Over");
                isGameOver = true;
            }
            
            // if ball is hit by cannonball, game over
            if (this.cannonballHit)
            {
                Debug.Log("Game Over");
                isGameOver = true;
            }
            // if ball fall into hole, game over
            if (this.isIntoHole)
            {
                this.ballStayDeltaTime += Time.deltaTime;
                
                if (!(this.ballStayDeltaTime > ballStayTime)) return;

                isGameOver = true;
                Debug.Log("Game Over");
            }
            
            // if ball isn't on tile, game over
            if (!this.onTile)
            {
                isGameOver = true;
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Cannonball"))
            {
                this.cannonballHit = true;
            }
            else if (other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Breakable"))
            {
                this.blockHit = true;
            }
            else if (other.gameObject.CompareTag("InPortal"))
            {
                Debug.Log("Portal move");
            }
        }


        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("AroundHole"))
            {
                outHole();
                return;
            }

            this.isIntoHole = true;
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("AroundHole"))
            {
                outHole();
            }
        }


        private void outHole()
        {
            this.isIntoHole = false;
            this.ballStayDeltaTime = 0.0f;
        }
    }
}
