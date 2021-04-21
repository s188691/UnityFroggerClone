using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsDrown : MonoBehaviour
{
    public GameObject[] logs = new GameObject[28];
    public int randomLog;
    public float startTime = 1f;
    public float drownIntervals = 5f;
    public float drownTime = 5f;
    public Color halfOpacity = Color.white;
    public Color zeroOpacity = Color.white;

    void Start()
    {
        halfOpacity.a = 0.50f;
        zeroOpacity.a = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (startTime > 0)
        {
            startTime -= 1 * Time.deltaTime; 
        } 
        else
        {
            StartCoroutine(LogDrownCoroutine());
            startTime = drownIntervals;
        }

        
    }

    public void RandomLog()
    {
        randomLog = Random.Range(0,27);
    }


    private IEnumerator LogDrownCoroutine()
    {
        RandomLog();
        logs[randomLog].GetComponent<SpriteRenderer>().color = halfOpacity;
        yield return new WaitForSeconds(2f);
        logs[randomLog].GetComponent<BoxCollider2D>().enabled = false;
        logs[randomLog].GetComponent<SpriteRenderer>().enabled = false;
        logs[randomLog].GetComponent<SpriteRenderer>().color = zeroOpacity;
        yield return new WaitForSeconds(drownTime);
        logs[randomLog].GetComponent<BoxCollider2D>().enabled = true;
        logs[randomLog].GetComponent<SpriteRenderer>().enabled = true;
    }

}
