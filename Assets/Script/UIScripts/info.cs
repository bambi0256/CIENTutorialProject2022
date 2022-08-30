using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    public static info instance;

    [SerializeField] GameObject[] inform = null;


    void Start()
    {
        instance = this; }

    public void DeleteBubble(string gimmickName)
    {
        for(int i = 0; i < inform.Length; i++)
        {
            if(inform[i].name == gimmickName)
            {
                inform[i].SetActive(false);
            }
        }
    }
}
