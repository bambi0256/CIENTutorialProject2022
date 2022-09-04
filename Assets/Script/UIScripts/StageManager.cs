using System;
using UnityEngine;

namespace UIScripts
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] LockedStages;
        [SerializeField] private Unlock[] Locked;
        [SerializeField] private GameObject[] NextStages;
        [SerializeField] private GameObject ClearUI;
        [SerializeField] private GameObject[] BubbleUI;
        [SerializeField] private GameObject[] SetBack;
        private int currentStage;

        private void Awake()
        {
            for (var i = 0; i < LockedStages.Length; i++)
            {
                Locked[i] = LockedStages[i].GetComponent<Unlock>();
            }
        }
        
        public void UnlockNext()
        {
            Locked[currentStage].UnLockStage();
        }

        public void NextStageBtn()
        {
            for (var i = 0; i < NextStages.Length; i++)
            {
                if (NextStages[i].activeSelf) { currentStage = i; break; }
            }

            NextStages[currentStage++].SetActive(false);
            NextStages[currentStage].SetActive(true);
            SetStageBack();

            ClearUI.SetActive(false);


            if (NextStages[currentStage] == NextStages[0])
            {
                BubbleUI[0].SetActive(true);

                Invoke(nameof(DestroyInfo), 4f);
            }
            else if (NextStages[currentStage] == NextStages[3])
            {
                BubbleUI[1].SetActive(true);
                Invoke(nameof(DestroyInfo), 18f);
            }
            else if (NextStages[currentStage] == NextStages[4])
            {
                BubbleUI[2].SetActive(true);
                Invoke(nameof(DestroyInfo), 15f);
            }
            else if (NextStages[currentStage] == NextStages[6])
            {
                BubbleUI[3].SetActive(true);
                Invoke(nameof(DestroyInfo), 10f);
            }
            else if (NextStages[currentStage] == NextStages[7])
            {
                BubbleUI[4].SetActive(true);
                Invoke(nameof(DestroyInfo), 15f);
            }
        }

        private void SetStageBack()
        {
            if (NextStages[currentStage] == NextStages[3])
            {
                SetBack[0].SetActive(false);
                SetBack[1].SetActive(true);
            }
            if (NextStages[currentStage] == NextStages[6])
            {
                SetBack[1].SetActive(false);
                SetBack[2].SetActive(true);
            }
            if (NextStages[currentStage] == NextStages[9])
            {
                SetBack[2].SetActive(false);
                SetBack[3].SetActive(true);
            }
        }
        public void DestroyInfo()
        {
            for (var k = 0; k < 5; k++)
                BubbleUI[k].SetActive(false);
        }

        public void SelectStage()
        {

            for (int i = 0; i < NextStages.Length; i++)
            {
                if (NextStages[i].activeSelf) { currentStage = i; break; }
            }
            SetStageBack();

            if (NextStages[currentStage] == NextStages[0])
            {
                BubbleUI[0].SetActive(true);

                Invoke(nameof(DestroyInfo), 4f);
            }
            else if (NextStages[currentStage] == NextStages[3])
            {
                BubbleUI[1].SetActive(true);
                Invoke(nameof(DestroyInfo), 18f);
            }
            else if (NextStages[currentStage] == NextStages[4])
            {
                BubbleUI[2].SetActive(true);
                Invoke(nameof(DestroyInfo), 15f);
            }
            else if (NextStages[currentStage] == NextStages[6])
            {
                BubbleUI[3].SetActive(true);
                Invoke(nameof(DestroyInfo), 10f);
            }
            else if (NextStages[currentStage] == NextStages[7])
            {
                BubbleUI[4].SetActive(true);
                Invoke(nameof(DestroyInfo), 15f);
            }

        }


        public void QuitBtn()
        {
            NextStages[currentStage].SetActive(false);
        }
        public void restartBtn()
        {


            NextStages[currentStage].SetActive(false);
            NextStages[currentStage].SetActive(true);

        }
        public void Level1()
        {
            Invoke(nameof(DestroyInfo), 5f);
        }
    }
}