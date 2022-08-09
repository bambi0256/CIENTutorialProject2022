using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public GameObject SuccessUI;
    public GameObject FailUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SuccessStage();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            FailStage();
    }

    void SuccessStage()
    {
        SuccessUI.SetActive(true);
    }
    void FailStage()
    {
        FailUI.SetActive(true);
    }
}
