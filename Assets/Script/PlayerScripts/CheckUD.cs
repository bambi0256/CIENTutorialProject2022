using UnityEngine;

namespace PlayerScripts
{
    public class CheckUD : MonoBehaviour
    {
        public bool Flag;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Tile") || col.gameObject.CompareTag("OutPortal")) Flag = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Tile") || other.gameObject.CompareTag("OutPortal")) Flag = false;
        }
    }
}
