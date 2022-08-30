using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] GameObject[] Map;
    [SerializeField] GameObject[] info;

    public void AllOffMap()
    {
        for(int i = 0; i < Map.Length; i++)
        { Map[i].SetActive(false); }
    }
    public void AllOffinfo()
    {
        for (int i = 0; i < info.Length; i++)
        { info[i].SetActive(false); }
    }
}
