using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ���� UI�� ��� �����ϰ� ������ �� �ֵ��� �ϴ� UI �Ŵ���

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


    public GameObject GameOverUI; //���� ������ Ȱ��ȭ�Ǵ� UI

    // ���ӿ��� UI Ȱ��ȭ
    public void SetActiveGameoverUI(bool active)
    {
        GameOverUI.SetActive(active);
    }
    // ���� ���� ��ư
    public void StartGame()
    {
        SceneManager.LoadScene("StageScene");
    }

    // ���� ����� ��ư
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ���� ���� ��ư
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    //â �ݱ� ��ư
    public void closeButoon()
    {
        gameObject.SetActive(false);
    }
}