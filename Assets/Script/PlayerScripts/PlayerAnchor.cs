using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerAnchor : MonoBehaviour
    {
        public bool isTileOn;
        private GameObject parent;
        private PlayerController playerController;

        // Start is called before the first frame update
        private void Start()
        {
            parent = transform.parent.gameObject;
            playerController = parent.GetComponent<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Tile"))
            {
                isTileOn = true;
            }
            else if (other.gameObject.CompareTag("Cannonball"))
            {
                playerController.setCannonballHit();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Tile"))
            {
                isTileOn = true;
            }
        }
    }
}
