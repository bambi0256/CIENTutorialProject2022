using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeStage()
    {
        switch (this.gameObject.name)
        {
            case "Stage1":
                SceneManager.LoadScene("Stage1");
                break;
            case "Stage2":
                SceneManager.LoadScene("Stage2");
                break;
            case "Stage3":
                SceneManager.LoadScene("Stage3");
                break;
            case "Stage4":
                SceneManager.LoadScene("Stage4");
                break;
        }

    }
}
