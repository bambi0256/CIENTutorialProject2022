using System;
using BallScripts;
using TileScripts;
using UnityEngine;

namespace UIScripts
{
    public class ResultUI : MonoBehaviour
    {
        public GameObject SuccessUI;
        public GameObject FailUI;

        public BallMove BM;
        private StageManager SM;

        // Update is called once per frame
        private void Awake()
        {
            SM = GameObject.Find("StageManager").GetComponent<StageManager>();
        }

        private void Update()
        {
            if (!BM) return;
            if (BM.isClear)
            {
                SM.UnlockNext();
                SuccessStage();
            }
            else if (BM.isGameOver)
                FailStage();
        }

        private void SuccessStage()
        {
            SuccessUI.SetActive(true);
            BM = null;
        }
        private void FailStage()
        {
            FailUI.SetActive(true);
            BM = null;
        }
    }
}
