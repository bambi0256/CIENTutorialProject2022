using UnityEngine;

namespace Script.ObjectScripts
{
    public class HoleAnchor : MonoBehaviour
    {
        private bool isClose;
        private Hole parentScript;

        // Start is called before the first frame update
        void Start()
        {
            this.parentScript = transform.parent.gameObject.GetComponent<Hole>();
        }


        public void holeClose()
        {
            this.parentScript.holeClose();
            setLayer();
            this.isClose = true;
        }


        private void setLayer()
        {
            // layer 0 is Default
            gameObject.layer = 0;
        }


        public bool getIsClose()
        {
            return this.isClose;
        }
    }
}
