using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 pos;
    [SerializeField] private bool moveRight = true;
    [SerializeField] private float moveSpeed;
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
            if (pos.x >= 10)
            {
                pos.x = -10;
            }
        }
        else
        {
            pos += Vector2.left * moveSpeed * Time.deltaTime;
            if (pos.x <= -10)
            {
                pos.x = 10;
            }
        }

        transform.position = pos;
        
    }
}
