using System;
using UnityEngine;

namespace TileScripts
{
    public class CheckBallCollision : MonoBehaviour
    {
        public bool isBallCol;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball"))
            {
                isBallCol = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Ball"))
            {
                isBallCol = false;
            }
        }
    }
}
