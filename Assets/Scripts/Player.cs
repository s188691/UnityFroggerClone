using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite playerUp, playerDown, playerRight, playerLeft;
    public Vector2 pos, startPos;
    public bool onLog;
    public bool moveRight;
    public int health = 3;
    [SerializeField] private float moveSpeed;
    public float logSize = 0f;
    public GameObject GameManager;


    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = GameManager.GetComponent<GameStates>().levelSpeed;

        FroggerMovement();
        transform.position = pos;

        if (health <= 0)
        {
            GameManager.GetComponent<GameStates>().GameOver();
        }

        if (transform.position.x >= 9 || transform.position.x <= -9)
        {
            BlockedPoint();
        }
        
    }

    public void FroggerMovement()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().sprite = playerUp;
            pos += Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && pos.y > -6)
        {
            GetComponent<SpriteRenderer>().sprite = playerDown;
            pos += Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && pos.x > -8)
        {
            GetComponent<SpriteRenderer>().sprite = playerLeft;
            pos += Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && pos.x < 8)
        {
            GetComponent<SpriteRenderer>().sprite = playerRight;
            pos += Vector2.right;
        }

        if (onLog && moveRight)
        {
            pos += Vector2.right * moveSpeed * Time.deltaTime;
            if (pos.x >= (29+(3*logSize)))
            {
                pos.x = (-9-logSize);
            }
        }
        else if (onLog && !moveRight)
        {
            pos += Vector2.left * moveSpeed * Time.deltaTime;
            if (pos.x <= (-29-(3*logSize)))
            {
                pos.x = (9+logSize);
            }
        }
    }

    public void FroggerDeath()
    {
        if(!onLog)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            ResetPosition();
            health -= 1;
            GameManager.GetComponent<PointsSystem>().playerHeight = -7;
        }
    }
    public void BlockedPoint()
    {
        ResetPosition();
        health -= 1;
        GameManager.GetComponent<PointsSystem>().playerHeight = -7;
    }

    public void ResetPosition()
    {
        pos = startPos;
        GetComponent<SpriteRenderer>().sprite = playerUp;
        GetComponent<BoxCollider2D>().enabled = true;
        GameManager.GetComponent<GameStates>().ResetTimer();
    }

}
