using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 target_position;
    private Vector3 pre_position;
    [SerializeField] private float tile_length = 1.0f;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float movingTriggerTime = 0.2f;
    [SerializeField] private float movingDelayTime = 0.2f;
    private float movingTriggerDeltaTime;
    private float movingDelayDeltaTime;

    private bool buttonFlagUp = false;
    private bool buttonFlagDown = false;
    private bool buttonFlagLeft = false;
    private bool buttonFlagRight = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTurn(180.0f);
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
                this.buttonFlagUp = true;

                this.target_position.y += this.tile_length;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerTurn(180.0f);
                this.buttonFlagDown = true;

                this.target_position.y -= this.tile_length;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerTurn(90.0f);
                this.buttonFlagLeft = true;

                this.target_position.x -= this.tile_length;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerTurn(-90.0f);
                this.buttonFlagRight = true;
                
                this.target_position.x += this.tile_length;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, this.target_position, this.speed);
        }


        if (this.buttonFlagUp && (Input.GetKey(KeyCode.UpArrow) ^ Input.GetKey(KeyCode.W)))
        {
            moving();
        }
        if (this.buttonFlagDown && (Input.GetKey(KeyCode.DownArrow) ^ Input.GetKey(KeyCode.S)))
        {
            moving();
        }
        if (this.buttonFlagLeft && (Input.GetKey(KeyCode.LeftArrow) ^ Input.GetKey(KeyCode.A)))
        {
            moving();
        }
        if (this.buttonFlagRight && (Input.GetKey(KeyCode.RightArrow) ^ Input.GetKey(KeyCode.D)))
        {
            moving();
        }
        

        /*
        // if direction keys are up
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            this.movingTriggerDeltaTime = 0.0f;
        }
        */
    }


    private void playerTurn(float direction)
    {
        transform.rotation = Quaternion.Euler(0, 0, direction);
        buttonFlagFalse();
        this.movingTriggerDeltaTime = 0.0f;
    }


    private void buttonFlagFalse()
    {
        this.buttonFlagUp = false;
        this.buttonFlagDown = false;
        this.buttonFlagLeft = false;
        this.buttonFlagRight = false;
    }


    private void moving()
    {
        this.movingTriggerDeltaTime += Time.deltaTime;
        this.movingDelayDeltaTime += Time.deltaTime;

        if (this.movingTriggerDeltaTime > this.movingTriggerTime)
        {
            if (Mathf.Approximately(transform.position.x, target_position.x) && Mathf.Approximately(transform.position.y, target_position.y))
            {
                if (this.movingDelayDeltaTime > this.movingDelayTime)
                    setTargetPosition();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, this.target_position, this.speed);

                this.movingDelayDeltaTime = 0.0f;
            }
        }
    }


    private void setTargetPosition()
    {
        if (buttonFlagUp)
            this.target_position.y += this.tile_length;
        else if (buttonFlagDown)
            this.target_position.y -= this.tile_length;
        else if (buttonFlagLeft)
            this.target_position.x -= this.tile_length;
        else if (buttonFlagRight)
            this.target_position.x += this.tile_length;
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
