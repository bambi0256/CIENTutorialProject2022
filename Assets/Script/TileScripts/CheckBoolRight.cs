using UnityEngine;

namespace TileScripts
{
    public class CheckBoolRight : MonoBehaviour
    {
        private bool isThere;
        internal bool Flag;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Tile"))
            {
                isThere = true;
            }
        }
    
        private void Update()
        {
            if (!isThere || Flag) return;
            Flag = true;
        }
    }
}
