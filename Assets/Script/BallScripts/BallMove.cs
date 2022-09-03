using ObjectScripts;
using UnityEngine;

namespace BallScripts
{
    public class BallMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        public static int BallDir;
        // 0 = stop, 1 = up, 2 = right, 3 = down, 4 = left
        public float BallSpeed;

        private readonly Vector2 Up = new Vector2(0, 1);
        private readonly Vector2 Right = new Vector2(1, 0);
        private readonly Vector2 Down = new Vector2(0, -1);
        private readonly Vector2 Left = new Vector2(-1, 0);
        private readonly Vector2 Stop = new Vector2(0, 0);

        private bool cannonballHit;
        private bool blockHit;
        private bool isIntoHole;
        private bool inPortal;
        private bool inGoal;

        private bool isGameOver;
        private bool isClear;

        private float portalDelayTime;
        private float portalDelayDeltaTime;
        private InPortal inPortalScript;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            BallSpeed = 40.0f;
            this.portalDelayTime = 0.5f;

            this.portalDelayDeltaTime = 0.0f;

            this.cannonballHit = false;
            this.blockHit = false;
            this.isIntoHole = false;
            this.inPortal = false;
            this.inGoal = false;
            this.isGameOver = false;
            this.isClear = false;

            _rigidbody2D.velocity = Stop;
        }

        private void FixedUpdate()
        {
            Move();
            CheckDeath();
        }

        private void Move()
        {
            if (this.inPortal)
            {
                this.portalDelayDeltaTime += Time.deltaTime;

                if (!(this.portalDelayDeltaTime > this.portalDelayTime)) return;

                transform.position = this.inPortalScript.getDestinationPosition();
                this.inPortal = false;
            }

            _rigidbody2D.velocity = BallDir switch
            {
                1 => Up * (Time.deltaTime * BallSpeed),
                2 => Right * (Time.deltaTime * BallSpeed),
                3 => Down * (Time.deltaTime * BallSpeed),
                4 => Left * (Time.deltaTime * BallSpeed),
                _ => _rigidbody2D.velocity
            };
            /*
            if (isClear || isGameOver)
            {
                _rigidbody2D.velocity = Vector2.zero;
            }*/
        }

        private void CheckDeath()
        {
            // if ball get collision with wall, game over
            if (this.blockHit)
            {
                isGameOver = true;
                Debug.Log("Block Hit Game Over");
            }

            // if ball is hit by cannonball, game over
            if (this.cannonballHit)
            {
                isGameOver = true;
                Debug.Log("Bullet Hit Game Over");
            }

            // if ball fall into hole, game over
            if (this.isIntoHole)
            {
                isGameOver = true;
                Debug.Log("Hole Game Over");
            }
            
            // if ball isn't on tile, game over
            
            // if ball get in GoalTIle, game clear
            if (inGoal)
            {
                isClear = true;
                Debug.Log("Clear Game");
                
                // 맵 오픈 체크 함수
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Breakable"))
            {
                this.blockHit = true;
            }
            else if (other.gameObject.CompareTag("InPortal"))
            {
                this.inPortal = true;
                this.inPortalScript = other.gameObject.GetComponent<InPortal>();
                _rigidbody2D.velocity = Stop;
            }

            if (other.CompareTag("Goal"))
            {
                inGoal = true;
            }
        }

        public void setIsIntoHole()
        {
            this.isIntoHole = true;

            AudioManager.instance.PlaySFX("InHole");
        }
        
        public void setCannonballHit()
        {
            this.cannonballHit = true;
        }
    }
}
