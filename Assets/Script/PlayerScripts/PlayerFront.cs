using UnityEngine;

namespace PlayerScripts
{
    public class PlayerFront : MonoBehaviour
    {
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

            if (!(front.CompareTag("Breakable") || front.CompareTag("Portal") || front.CompareTag("Turret")))
                return;
            
            playerController.setFrontObject(front);
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            front = other.gameObject;

            // layer 8 is Obstruction
            if (front.layer == 8)
                playerController.setIsObstruct(false);
            

            if (!(front.CompareTag("Breakable") || front.CompareTag("Portal") || front.CompareTag("Turret")))
                return;

            playerController.resetFrontObject();
        }
    }
}
