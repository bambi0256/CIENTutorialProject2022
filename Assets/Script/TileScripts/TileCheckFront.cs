using UnityEngine;

namespace TileScripts
{
    public class TileCheckFront : MonoBehaviour
    {
        private ToSlowTile toSlowTileScript;

        // Start is called before the first frame update
        void Start()
        {
            this.toSlowTileScript = transform.parent.GetComponent<ToSlowTile>();
        }

        
        public void setIsSlow()
        {
            this.toSlowTileScript.setIsSlow();
        }
    }
}
