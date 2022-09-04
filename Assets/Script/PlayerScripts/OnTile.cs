using UnityEngine;

namespace PlayerScripts
{
    public class OnTile : MonoBehaviour
    {
        public bool OnSwitch;
        public bool OnOutPortal;
    
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Circuit"))
            {
                OnSwitch = true;
            }

            if (other.gameObject.CompareTag("OutPortal"))
            {
                OnOutPortal = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Circuit"))
            {
                OnSwitch = false;
            }
            
            if (other.gameObject.CompareTag("OutPortal"))
            {
                OnOutPortal = false;
            }
        }
    }
}
