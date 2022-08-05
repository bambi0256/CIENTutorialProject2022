using UnityEngine;

namespace Script.ObjectScripts
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] private GameObject cannonballPrefab;
        private float cannonballGenerateTime = 2.0f;
        private float deltaTime = 0.0f;


        // Update is called once per frame
        private void Update()
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
