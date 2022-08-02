using Script.BallScripts;
using UnityEngine;

namespace Script.TileScripts
{
    public class RuleD : MonoBehaviour
    {
        private int GetDir;
        private int SetDir;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.CompareTag("Ball")) return;
            GetDir = BallMove.BallDir;
            SetDir = (GetDir == 4) ? 5 : 4;
            BallMove.BallDir = SetDir;
        }
    }
}
