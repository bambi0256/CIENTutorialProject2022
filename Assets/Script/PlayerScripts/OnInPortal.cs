using UnityEngine;

namespace PlayerScripts
{
    public class OnInPortal : MonoBehaviour
    {
        private GameObject parent;
        private PlayerController playerController;


        private void Start()
        {
            parent = transform.parent.parent.gameObject;
            playerController = parent.GetComponent<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("InPortal"))
            {
                playerController.setIsOnInPortal(true);
                playerController.setInPortalObject(other.gameObject);
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("InPortal"))
            {
                playerController.setIsOnInPortal(false);
            }
        }
    }
}
