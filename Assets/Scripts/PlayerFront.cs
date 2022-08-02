using UnityEngine;

public class PlayerFront : MonoBehaviour
{
    [SerializeField] private bool isBlock = false;
    [SerializeField] private bool isPortal = false;
    [SerializeField] private bool isBreakable = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstruction"))
        {
            this.isBlock = true;
        }
        else if (other.gameObject.CompareTag("Portal"))
        {
            this.isPortal = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstruction"))
        {
            this.isBlock = false;
        }
        else if (other.gameObject.CompareTag("Portal"))
        {
            this.isPortal = false;
        }
    }
}
