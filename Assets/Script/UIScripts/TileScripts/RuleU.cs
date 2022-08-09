using Script.BallScripts;
using UnityEngine;

namespace Script.TileScripts
{
    public class RuleU : MonoBehaviour
    {
        private int GetDir;
        private int SetDir;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.CompareTag("Ball")) return;
            GetDir = BallMove.BallDir;
            SetDir = (GetDir == 1) ? 5 : 1;
            BallMove.BallDir = SetDir;
        }
    }
}
