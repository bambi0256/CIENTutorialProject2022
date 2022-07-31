using UnityEngine;

namespace Script.TileScripts
{
    public class EndTile : MonoBehaviour
    {
        private bool isClear;
        public GameObject EndPopUp;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag($"Ball")) return;
            isClear = true;
        }

        private void Update()
        {
            if (!isClear == false) return;
            EndPopUp.SetActive(true);
        }
    }
}
