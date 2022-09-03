using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBreakable : MonoBehaviour
{
    [SerializeField] private GameObject[] breakables = new GameObject[1];
    private int count;


    private void Awake()
    {
        this.count = breakables.Length;
    }


    private void OnEnable()
    {
        for (int i = 0; i < this.count; i++)
        {
            this.breakables[i].SetActive(true);
        }
    }
}
