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

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UnLockStage();

            }

        }
        public void UnLockStage()
        {
            button.interactable = true;
            //button.image.sprite = null;
            text.SetActive(true);
            if (OpenImage != null)
            { OpenImage.SetActive(true); }
            LockImage.SetActive(false);
        }
    }
}