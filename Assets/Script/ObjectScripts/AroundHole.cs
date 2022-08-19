using BallScripts;
using UnityEngine;

namespace ObjectScripts
{
    public class AroundHole : MonoBehaviour
    {
        private Hole parentScript;

        private bool ballEnter;
        private bool isClose;


        // Start is called before the first frame update
        void Start()
        {
            this.parentScript = transform.parent.gameObject.GetComponent<Hole>();
        }


        private void Update()
        {
            if (this.ballEnter)
            {
                this.isClose = this.parentScript.getIsClose();

                if (this.isClose)
                {
                    gameObject.tag = "Untagged";
                    this.ballEnter = false;
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;

            this.ballEnter = true;
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;

            this.ballEnter = false;
        }
    }
}
