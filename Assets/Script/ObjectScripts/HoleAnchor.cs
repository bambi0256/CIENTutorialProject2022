using UnityEngine;

namespace ObjectScripts
{
    public class HoleAnchor : MonoBehaviour
    {
        private bool isClose;
        private Hole parentScript;
        private int defaultLayer;


        private void Awake()
        {
            this.defaultLayer = gameObject.layer;
        }


        private void OnEnable()
        {
            this.isClose = false;
            gameObject.layer = this.defaultLayer;
        }

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
