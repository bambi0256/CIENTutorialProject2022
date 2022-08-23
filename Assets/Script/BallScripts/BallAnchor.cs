using UnityEngine;

namespace BallScripts
{
    public class BallAnchor : MonoBehaviour
    {
        private BallMove parentScript;

        // Start is called before the first frame update
        private void Start()
        {
            this.parentScript = transform.parent.gameObject.GetComponent<BallMove>();
        }


        public void setIsIntoHole()
        {
            parentScript.setIsIntoHole();
        }
    }
}
