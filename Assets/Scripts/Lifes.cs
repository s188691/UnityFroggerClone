using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Text lifes;
    private int health;

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<Player>().health;
        lifes.text = health.ToString();
    }
}
