using UnityEngine;

namespace Script.TileScripts
{
    public class StartTile : MonoBehaviour
    {
        public GameObject Ball;
    
        private void Start()
        {
            var position = transform.position;
            var pos = new Vector3(position.x, position.y, position.z - 1);
            Instantiate(Ball, pos, Quaternion.identity);
        }
    }
}
