using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 target_position;
    private Vector3 pre_position;
    [SerializeField] private float tile_length = 1.0f;
    [SerializeField] private float speed = 0.05f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(transform.position.x, target_position.x) && Mathf.Approximately(transform.position.y, target_position.y))
        {
            this.pre_position = transform.position;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerTurn(0.0f);

                this.target_position.y += this.tile_length;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerTurn(180.0f);

                this.target_position.y -= this.tile_length;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerTurn(90.0f);

                this.target_position.x -= this.tile_length;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerTurn(-90.0f);
                
                this.target_position.x += this.tile_length;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, this.target_position, this.speed);
        }
    }


    private void playerTurn(float direction)
    {
        transform.rotation = Quaternion.Euler(0, 0, direction);
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Obstruction")
        {
            this.target_position = this.pre_position;
        }
        else if (other.gameObject.tag == "Portal")
        {
            Debug.Log("move another portal");
        }
    }
}
