using UnityEngine;

namespace TileScripts
{
    public class CheckBoolRight : MonoBehaviour
    {
        public bool posFlag;
        public bool Flag;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Tile")) return;
            Flag = true;
            switch (col.gameObject.name)
            {
                case "StartTile" when col.gameObject.GetComponent<StartTile>().Type == 1:
                case "RoadTile(Clone)" when col.gameObject.GetComponent<ChangeNoneTo>().Type == 1:
                    posFlag = true;
                    break;
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Tile")) return;
            posFlag = false;
            Flag = false;
        }
    }
}
