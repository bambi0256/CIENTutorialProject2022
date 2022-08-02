using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//클리어 시간이나 게임오버 상태를 관리하는 게임 매니저

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;


    public bool isGameOver { get; private set; } //게임 오버 상태

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {


    }

    public void EndGame()
    {
        isGameOver = true;
        UIManagers.Instance.SetActiveGameoverUI(true);
    }

    void Update()
    {

    }
}