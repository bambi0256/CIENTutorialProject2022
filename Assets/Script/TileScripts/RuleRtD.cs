using Script.BallScripts;
using UnityEngine;

namespace Script.TileScripts
{
    public class RuleRtD : MonoBehaviour
    {
        private int GetDir;
        private int SetDir;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.CompareTag("Ball")) return;
            GetDir = BallMove.BallDir;
            SetDir = (GetDir == 2) ? 4 : 2;
            BallMove.BallDir = SetDir;
        }
    }
}
