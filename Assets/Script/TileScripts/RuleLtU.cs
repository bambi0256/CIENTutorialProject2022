using Script.BallScripts;
using UnityEngine;

namespace Script.TileScripts
{
    public class RuleLtU : MonoBehaviour
    {
        private int GetDir;
        private int SetDir;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.CompareTag("Ball")) return;
            GetDir = BallMove.BallDir;
            SetDir = (GetDir == 3) ? 1 : 3;
            BallMove.BallDir = SetDir;
        }
    }
}
