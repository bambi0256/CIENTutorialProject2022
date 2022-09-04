using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class Unlock : MonoBehaviour
    {
        //private Sprite LockImage;
        public GameObject LockImage;
        public GameObject OpenImage;
        public Button button;
        public GameObject text;

        private void Start()
        {
            button.interactable = false;
        }

        public void UnLockStage()
        {
            button.interactable = true;
            text.SetActive(true);
            if (!OpenImage)
            {
                LockImage.SetActive(false);
            }
            else
            {
                OpenImage.SetActive(true);
                LockImage.SetActive(false);
            }
        }
    }
}