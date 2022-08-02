using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFront : MonoBehaviour
{
    [SerializeField] private bool isBlock = false;
    [SerializeField] private bool isPortal = false;
    [SerializeField] private bool isBreakable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstruction")
        {
            this.isBlock = true;
        }
        else if (other.gameObject.tag == "Portal")
        {
            this.isPortal = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstruction")
        {
            this.isBlock = false;
        }
        else if (other.gameObject.tag == "Portal")
        {
            this.isPortal = false;
        }
    }
}
