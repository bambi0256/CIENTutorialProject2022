using UnityEngine;

namespace TileScripts
{
    public class CheckBoolLeft : MonoBehaviour
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
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Tile"))
            {
                isThere = false;
            }
        }

        private void Update()
        {
            Flag = isThere switch
            {
                true => true,
                false => false
            };
        }
    }
}
