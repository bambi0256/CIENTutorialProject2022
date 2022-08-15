using BallScripts;
using UnityEngine;

namespace TileScripts
{
    public class StartTile : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball"))
            {
                BallMove.BallDir = 2;
            }
        }
    }
}
