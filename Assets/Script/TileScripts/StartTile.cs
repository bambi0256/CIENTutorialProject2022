using System;
using System.Runtime.CompilerServices;
using BallScripts;
using UnityEngine;

namespace TileScripts
{
    public class StartTile : MonoBehaviour
    {
        public GameObject Ball;
        

        private void Awake()
        {
            var position = transform.position;
            var BallPos = new Vector3(position.x, position.y, position.z - 1);
            Instantiate(Ball, BallPos, Quaternion.identity);
        }
    }
}
