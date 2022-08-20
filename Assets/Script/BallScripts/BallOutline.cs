using UnityEngine;

namespace BallScripts
{
    public class BallOutline : MonoBehaviour
    {
        private BallMove parentScript;

        // Start is called before the first frame update
        private void Start()
        {
            this.parentScript = transform.parent.gameObject.GetComponent<BallMove>();
        }

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Cannonball"))
            {
                this.parentScript.setCannonballHit();
            }
        }
    }
}
