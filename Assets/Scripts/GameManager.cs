using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ŭ���� �ð��̳� ���ӿ��� ���¸� �����ϴ� ���� �Ŵ���

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


    public bool isGameOver { get; private set; } //���� ���� ����

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