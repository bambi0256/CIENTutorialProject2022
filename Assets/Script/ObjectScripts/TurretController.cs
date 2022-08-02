using UnityEngine;

namespace Script.ObjectScripts
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] private GameObject cannonballPrefab;
        //[SerializeField] private float tile_length = 1.0f;
        private float cannonballGenerateTime = 2.0f;
        private float deltaTime = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            deltaTime += Time.deltaTime;

            if (deltaTime > cannonballGenerateTime)
            {
                GameObject cannonball = Instantiate(cannonballPrefab) as GameObject;
                cannonball.transform.position = transform.position;
                cannonball.transform.rotation = transform.rotation;

                deltaTime = 0.0f;
            }
        }
    }
}
