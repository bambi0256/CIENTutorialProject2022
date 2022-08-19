using System;
using UnityEngine;

namespace TileScripts
{
    public class CheckBoolDown : MonoBehaviour
    {
        private bool isThere;
        internal bool Flag;
        
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Tile"))
            {
                isThere = true;
                Debug.Log("tile in Down");
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
