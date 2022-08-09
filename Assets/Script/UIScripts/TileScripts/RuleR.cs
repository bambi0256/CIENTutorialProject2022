using System;
using Script.BallScripts;
using UnityEngine;

namespace Script.TileScripts
{
    public class RuleR : MonoBehaviour
    {
        private int GetDir;
        private int SetDir;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.CompareTag("Ball")) return;
            GetDir = BallMove.BallDir;
            SetDir = (GetDir == 2) ? 5 : 2;
            BallMove.BallDir = SetDir;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag("Ball")) return;
            GetDir = BallMove.BallDir;
            SetDir = (GetDir == 2) ? 5 : 2;
            BallMove.BallDir = SetDir;
        }
    }
}
