using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerAnchor : MonoBehaviour
    {
        public bool OnSwitch;
        private GameObject parent;
        private PlayerController playerController;

        private void Start()
        {
            parent = transform.parent.gameObject;
            playerController = parent.GetComponent<PlayerController>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Switch") || other.gameObject.CompareTag("Circuit"))
            {
                OnSwitch = true;
            }

            if (other.gameObject.CompareTag("Cannonball"))
            {
                playerController.setCannonballHit();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Switch") || other.gameObject.CompareTag("Circuit"))
            {
                OnSwitch = false;
            }
        }
    }
}
