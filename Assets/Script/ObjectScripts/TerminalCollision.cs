using UnityEngine;

namespace Script.ObjectScripts
{
    public class TerminalCollision : MonoBehaviour
    {
        private GameObject parent;
        // 1 is up, 2 is down, 3 is left, 4 is right
        [SerializeField] private int direction;

        // Start is called before the first frame update
        void Start()
        {
            parent = transform.parent.gameObject;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log("col");
            if (other.gameObject.CompareTag("Switch") || other.gameObject.CompareTag("SwitchBarrier"))
            {
                parent.GetComponent<Terminal>().terminalCollision(this.direction);
                //Debug.Log("col ter");
            }
            else if (other.gameObject.CompareTag("Circuit"))
            {
                parent.GetComponent<Terminal>().circuitCollision(this.direction);
                //Debug.Log("col cir");
            }
        }
    }
}
