using UnityEngine;

namespace Script.PlayerScripts
{
    public class PlayerAnchor : MonoBehaviour
    {
        [SerializeField] private bool isCannonball = false;
        private GameObject parent;

        // Start is called before the first frame update
        private void Start()
        {
            parent = transform.parent.gameObject;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Cannonball"))
            {
                this.isCannonball = true;

                parent.GetComponent<PlayerController>().getShot();
            }
        }
    }
}
