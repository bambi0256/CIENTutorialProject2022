using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    [SerializeField] private float mapWidth;
    [SerializeField] private float mapHeight;
    [SerializeField] private float tileLength = 1.0f;
    [SerializeField] private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * this.tileLength * this.speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > this.mapWidth + 1 || Mathf.Abs(transform.position.y) > this.mapHeight + 1 )
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Anchor" || other.gameObject.tag == "Obstruction")
        {
            Destroy(gameObject);
        }
    }
}
