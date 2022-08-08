using UnityEngine;

namespace Script.ObjectScripts
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] private GameObject cannonballPrefab;
        private float cannonballGenerateTime = 2.0f;
        private float deltaTime = 0.0f;

        [SerializeField] private bool isPause;
        [SerializeField] private float pauseDelayTime;
        private float pauseDeltaTime;


        private void Start()
        {
            this.pauseDelayTime = 3.0f;
        }


        // Update is called once per frame
        private void Update()
        {
            if (this.isPause)
            {
                this.pauseDeltaTime += Time.deltaTime;

                if (!(this.pauseDeltaTime > this.pauseDelayTime)) return;
                this.pauseDeltaTime = 0.0f;
                this.isPause = false;
            }

            deltaTime += Time.deltaTime;

            if (deltaTime > cannonballGenerateTime)
            {
                GameObject cannonball = Instantiate(cannonballPrefab) as GameObject;
                cannonball.transform.position = transform.position;
                cannonball.transform.rotation = transform.rotation;

                deltaTime = 0.0f;
            }
            
        }


        public void setIsPause()
        {
            this.isPause = true;
        }
    }
}
