using System;
using System.Collections.Generic;
using TileScripts;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlayerScripts
{
    public class CheckUD : MonoBehaviour
    {
        public bool Flag;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Tile")) return;
            switch (col.gameObject.name)
            {
                case "StartTile" when col.gameObject.GetComponent<StartTile>().Type == 1:
                case "RoadTile(Clone)" when col.gameObject.GetComponent<ChangeNoneTo>().Type == 1:
                    Flag = true;
                    break;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Tile")) Flag = false;
        }
    }
}
