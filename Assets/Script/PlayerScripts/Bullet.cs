using UnityEngine;

namespace PlayerScripts
{
    public class Bullet : MonoBehaviour
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
            if (other.gameObject.CompareTag("Cannonball"))
            {
                playerController.setCannonballHit();
            }
        }
    }
}
