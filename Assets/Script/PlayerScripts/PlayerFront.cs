using UnityEngine;

namespace PlayerScripts
{
    public class PlayerFront : MonoBehaviour
    {
        [SerializeField] private bool isBlock = false;
        [SerializeField] private bool isPortal = false;
        [SerializeField] private bool isBreakable = false;
        private GameObject parent;
        private PlayerController playerController;
        private GameObject front;


        private void Start()
        {
            parent = transform.parent.gameObject;
            playerController = parent.GetComponent<PlayerController>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            front = other.gameObject;

            // layer 8 is Obstruction
            if (front.layer == 8)
                playerController.setIsObstruct(true);




            if (other.gameObject.CompareTag("Block"))
            {
                isBlock = true;
            }
            else if (other.gameObject.CompareTag("Portal"))
            {
                isPortal = true;
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            front = other.gameObject;

            // layer 8 is Obstruction
            if (front.layer == 8)
                playerController.setIsObstruct(false);
            

            if (other.gameObject.CompareTag("Block"))
            {
                isBlock = false;
            }
            else if (other.gameObject.CompareTag("Portal"))
            {
                isPortal = false;
            }
        }
    }
}
