using UnityEngine;

namespace TileScripts
{
    public class CheckBoolDown : MonoBehaviour
    {
        public bool Flag;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Tile")) Flag = true;
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Tile")) Flag = false;
        }
    }
}
