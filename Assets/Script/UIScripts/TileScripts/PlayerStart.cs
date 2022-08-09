using UnityEngine;

namespace Script.TileScripts
{
    public class PlayerStart : MonoBehaviour
    {
        public GameObject player;

        private void Start()
        {
            var position = transform.position;
            var pos = new Vector3(position.x, position.y, position.z - 1);
            Instantiate(player, pos, Quaternion.identity);
        }
    }
}
