using UnityEngine;

namespace Script
{
    public class StartTile : MonoBehaviour
    {
        public GameObject Ball;
        private Vector3 pos;
    
        private void Start()
        {
            var position = transform.position;
            pos = new Vector3(position.x, position.y, position.z);
            Instantiate(Ball, pos, Quaternion.identity);
        }
    }
}
