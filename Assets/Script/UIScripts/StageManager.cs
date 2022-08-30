using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject[] NextStages;
    [SerializeField] GameObject ClearUI;
    [SerializeField] GameObject[] BubbleUI;
    int currentStage = 0;

    [SerializeField] Rigidbody PlayerRigid;
    [SerializeField] GameObject[] ForDestroy;

    public void ShowClearUI()
    {
        ClearUI.SetActive(true);

    }

    public void NextStageBtn()
    {
     NextStages[currentStage++].SetActive(false);
     NextStages[currentStage].SetActive(true);
     ClearUI.SetActive(false);
        if (NextStages[currentStage] == NextStages[3])
        {
            BubbleUI[1].SetActive(true);
        }
        else if (NextStages[currentStage] == NextStages[4])
        {
            BubbleUI[2].SetActive(true);
        }
        else if (NextStages[currentStage] == NextStages[6])
        {
            BubbleUI[3].SetActive(true);
        }
        else if (NextStages[currentStage] == NextStages[7])
        {
            BubbleUI[4].SetActive(true);
        }
    }
    public void QuitBtn()
    {
        NextStages[currentStage].SetActive(false);
    }
    public void restartBtn()
    {

        Reset();

        NextStages[currentStage].SetActive(false);
        NextStages[currentStage].SetActive(true);

    }

    public void Reset()
    {
     
        ForDestroy[0] = transform.Find("Player").gameObject;
        ForDestroy[1] = GameObject.Find("RoadTile(Clone)");
        ForDestroy[2] = GameObject.Find("Ball(Clone)");
        for (int i = 0; i < 3; i++)
        {
            Destroy(ForDestroy[i]);
        }
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
}
