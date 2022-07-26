using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 여러 UI에 즉시 접근하고 변경할 수 있도록 하는 UI 매니저

public class UIManager : MonoBehaviour
{
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    private static UIManager instance;


    public GameObject GameOverUI; //게임 오버시 활성화되는 UI

    // 게임오버 UI 활성화
    public void SetActiveGameoverUI(bool active)
    {
        GameOverUI.SetActive(active);
    }
    // 게임 시작 버튼
    public void StartGame()
    {
        SceneManager.LoadScene("StageScene");
    }

    // 게임 재시작 버튼
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 게임 종료 버튼
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    //창 닫기 버튼
    public void closeButoon()
    {
        gameObject.SetActive(false);
    }
}