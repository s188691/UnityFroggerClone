using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : MonoBehaviour
{

    [SerializeField] private bool moveRight = true;
    [SerializeField] private float moveSpeed;
    Vector2 pos;
    [SerializeField] private float logSize = 0f;
    public GameObject player;
    public GameObject GameManager;

    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        moveSpeed = GameManager.GetComponent<GameStates>().levelSpeed;

        if (moveRight)
        {
            pos += Vector2.right * moveSpeed * Time.deltaTime;
            if (pos.x >= (29+(3*logSize)))
            {
                pos.x = (-9-logSize);
            }
        }
        else
        {
            pos += Vector2.left * moveSpeed * Time.deltaTime;
            if (pos.x <= (-29-(3*logSize)))
            {
                pos.x = (9+logSize);
            }
        }

        transform.position = pos;
        
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        player.GetComponent<Player>().onLog = true;
        player.GetComponent<Player>().logSize = logSize;
        if(moveRight)
        {
            player.GetComponent<Player>().moveRight = true;
        }
        else if(!moveRight)
        {
            player.GetComponent<Player>().moveRight = false;
        }
    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        player.GetComponent<Player>().onLog = false;
    }
}
