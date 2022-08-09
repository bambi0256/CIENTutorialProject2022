using UnityEngine;

namespace Script.ObjectScripts
{
    public class InPortal : MonoBehaviour
    {
        [SerializeField] private GameObject outPortal;
        private Vector3 destinationPosition;

        // Start is called before the first frame update
        void Start()
        {
            this.destinationPosition = outPortal.transform.position;
        }


        public Vector3 getDestinationPosition()
        {
            return this.destinationPosition;
        }
    }
}
