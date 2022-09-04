using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject[] NextStages;
    [SerializeField] GameObject ClearUI;
    [SerializeField] GameObject[] BubbleUI;
    [SerializeField] GameObject[] SetBack;
    int currentStage= 0;

    public void ShowClearUI()
    {
        ClearUI.SetActive(true);

    }

    public void NextStageBtn()
    {
        for (int i = 0; i < NextStages.Length; i++)
        {
            if (NextStages[i].activeSelf == true) { currentStage = i; break; }
        }

        NextStages[currentStage++].SetActive(false);
        NextStages[currentStage].SetActive(true);
        SetStageBack();

        ClearUI.SetActive(false);


        if (NextStages[currentStage] == NextStages[0])
        {
            BubbleUI[0].SetActive(true);

            Invoke("DestroyInfo", 4f);
        }
        else if (NextStages[currentStage] == NextStages[3])
        {
            BubbleUI[1].SetActive(true);
            Invoke("DestroyInfo", 18f);
        }
        else if (NextStages[currentStage] == NextStages[4])
        {
            BubbleUI[2].SetActive(true);
            Invoke("DestroyInfo", 15f);
        }
        else if (NextStages[currentStage] == NextStages[6])
        {
            BubbleUI[3].SetActive(true);
            Invoke("DestroyInfo", 10f);
        }
        /*else if (NextStages[currentStage] == NextStages[7])
        {
            BubbleUI[4].SetActive(true);
            Invoke("DestroyInfo", 15f);
        }*/
    }
    public void SetStageBack()
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
        for (int k = 0; k < 5; k++)
            BubbleUI[k].SetActive(false);
    }

    public void SelectStage()
    {

        for (int i = 0; i < NextStages.Length; i++)
        {
            if (NextStages[i].activeSelf == true) { currentStage = i; break; }
        }
        SetStageBack();

        if (NextStages[currentStage] == NextStages[0])
        {
            BubbleUI[0].SetActive(true);

            Invoke("DestroyInfo", 4f);
        }
        else if (NextStages[currentStage] == NextStages[3])
        {
            BubbleUI[1].SetActive(true);
            Invoke("DestroyInfo", 18f);
        }
        else if (NextStages[currentStage] == NextStages[4])
        {
            BubbleUI[2].SetActive(true);
            Invoke("DestroyInfo", 15f);
        }
        else if (NextStages[currentStage] == NextStages[6])
        {
            BubbleUI[3].SetActive(true);
            Invoke("DestroyInfo", 10f);
        }
        /*else if (NextStages[currentStage] == NextStages[7])
        {
            BubbleUI[4].SetActive(true);
            Invoke("DestroyInfo", 15f);
        }
        */

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
        Invoke("DestroyInfo", 5f);
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}