using BallScripts;
using UnityEngine;

namespace ObjectScripts
{
    public class AroundHole : MonoBehaviour
    {
        private Hole parentScript;

        private bool isClose;

        private GameObject triggerObject;
        private GameObject ballAnchorObject;
        private bool ballEnter;
        private float ballStayTime;
        private float ballStayDeltaTime;


        private void OnEnable()
        {
            this.isClose = false;
            
            outHole();
        }


        // Start is called before the first frame update
        void Start()
        {
            this.parentScript = transform.parent.gameObject.GetComponent<Hole>();
            this.ballStayTime = 5.0f;
        }


        private void Update()
        {
            if (!this.isClose && this.ballEnter)
            {
                this.ballStayDeltaTime += Time.deltaTime;
                
                if (!(this.ballStayDeltaTime > ballStayTime)) return;

                this.ballEnter = false;
                this.ballAnchorObject.GetComponent<BallAnchor>().setIsIntoHole();
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            triggerObject = other.gameObject;

            if (!triggerObject.CompareTag("Ball")) return;

            //setBallAnchorObject(triggerObject);
            this.ballAnchorObject = triggerObject;

            this.ballEnter = true;
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;

            outHole();
        }


        private void setBallAnchorObject(GameObject other)
        {
            this.ballAnchorObject = other;
        }


        public void setIsClose()
        {
            this.isClose = true;
            outHole();
        }


        private void outHole()
        {
            this.ballEnter = false;
            this.ballStayDeltaTime = 0.0f;
        }
    }
}
