using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    public GameObject Text;
    public GameObject image1;
    public GameObject image2;

    Color color1;
    Color color2;


    void Start()
    {
        color1 = new Color(255 / 255f, 206 / 255f, 0 / 255f);
        color1.a = 255 / 255f;
        color2 = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        color2.a = 0 / 255f;


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouse()
    {

        Text.GetComponentInChildren<Outline>().effectColor = color1;
    }
    public void offMouse()
    {

        Text.GetComponentInChildren<Outline>().effectColor = color2;
    }
    public void SetColor()
    {
        Text.GetComponentInChildren<Outline>().effectColor = color2;
    }
    public void SetActiveimage1()
    {
       image1.SetActive(true);
       image2.SetActive(false);

    }
    public void SetActiveimage2()
    {
        image1.SetActive(false);
        image2.SetActive(true);
    }
}
    
