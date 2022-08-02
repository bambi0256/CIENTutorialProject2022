using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Script.BallScripts
{
    public class BallMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        
        public static int BallDir;
        // 0 = stop, 1 = up, 2 = right, 3 = left, 4 = down
        public static float BallSpeed;
        public static float Cooltime;

        private readonly Vector2 Up = new Vector2(0, 1);
        private readonly Vector2 Right = new Vector2(1, 0);
        private readonly Vector2 Left = new Vector2(-1, 0);
        private readonly Vector2 Down = new Vector2(0, -1);

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            BallSpeed = 10;
            Cooltime = 1;
        }

        private void FixedUpdate()
        {
            Move();
            CheckDeath();
            Debug.Log(BallDir);
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
            Cooltime = 1 / BallSpeed;
        }

        private void CheckDeath()
        {
            
        }
    }
}
