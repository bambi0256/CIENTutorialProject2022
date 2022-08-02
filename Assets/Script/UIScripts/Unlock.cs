using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class Unlock : MonoBehaviour
    {
        //private Sprite LockImage;
        public GameObject LockImage;
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
            LockImage.SetActive(false);
        }
    }
}