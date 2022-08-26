using UnityEngine;

namespace PlayerScripts
{
    public class CheckLR : MonoBehaviour
    {
        public bool Flag;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Tile")) Flag = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Tile")) Flag = false;
        }
    }
}
