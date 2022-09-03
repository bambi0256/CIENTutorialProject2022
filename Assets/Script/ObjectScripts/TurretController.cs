using UnityEngine;

namespace ObjectScripts
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] private GameObject cannonballPrefab;
        private float cannonballGenerateTime = 2.0f;
        private float deltaTime = 0.0f;

        [SerializeField] private bool isPause;
        [SerializeField] private float pauseDelayTime;
        private float pauseDeltaTime;

        private DurationChangeSprite durationScript;

        private GameObject parentMap;
        [SerializeField] private GameObject generatedObjectsPrefab;
        private GameObject generatedObjects;


        private void OnEnable()
        {
            this.parentMap = transform.parent.gameObject;
            this.generatedObjects = Instantiate(this.generatedObjectsPrefab) as GameObject;
            this.generatedObjects.transform.parent = this.parentMap.transform;

            this.deltaTime = 0.0f;
            this.isPause = false;
            this.pauseDeltaTime = 0.0f;
        }


        private void Start()
        {
            this.pauseDelayTime = 10.0f;

            this.durationScript = GetComponent<DurationChangeSprite>();
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

                cannonball.transform.parent = this.generatedObjects.transform;

                deltaTime = 0.0f;
            }
            
        }


        public void setIsPause()
        {
            this.isPause = true;
            this.durationScript.setTrigger();
        }
    }
}
