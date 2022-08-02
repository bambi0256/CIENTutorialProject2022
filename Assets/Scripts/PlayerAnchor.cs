using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnchor : MonoBehaviour
{
    [SerializeField] private bool isCannonball = false;
    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cannonball")
        {
            this.isCannonball = true;

            parent.GetComponent<PlayerController>().getShot();
        }
    }
}
