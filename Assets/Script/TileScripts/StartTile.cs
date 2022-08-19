using BallScripts;
using UnityEngine;

namespace TileScripts
{
    public class StartTile : MonoBehaviour
    {
        public GameObject Ball;
        public int Direction;
        public float DelayTime;

        private void Awake()
        {
            var position = transform.position;
            var BallPos = new Vector3(position.x, position.y, position.z - 1);
            Instantiate(Ball, BallPos, Quaternion.identity);
            Invoke(nameof(SetBallDir), DelayTime);
        }

        private void SetBallDir()
        {
            BallMove.BallDir = Direction;
        }
    }
}
