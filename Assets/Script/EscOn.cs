using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class EscOn : MonoBehaviour
    {
        public GameObject Esc;
    
        void Update()
        {
            if (!Input.GetKeyDown("escape")) return;
            Esc.SetActive(!Esc.activeSelf);
        }
    
        public void YesOutStage()
        {
            SceneManager.LoadScene("Select Stage");
        }

        public void NoOutStage()
        {
            Esc.SetActive(false);
        }
    }
}
