using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    public GameObject player;
    public void OnTriggerStay2D(Collider2D coll)
    {
        player.GetComponent<Player>().FroggerDeath();
    }
}
