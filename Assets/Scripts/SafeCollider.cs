using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCollider : MonoBehaviour
{
    public GameObject player;
    public GameObject PointsSystem;
    [SerializeField] private Sprite blockedPoint;
    [SerializeField] private Sprite availablePoint;
    public bool pointReceived = false;
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(!pointReceived)
        {
            PointsSystem.GetComponent<PointsSystem>().CheckpointReceived();
            player.GetComponent<Player>().ResetPosition();
            GetComponent<SpriteRenderer>().sprite = blockedPoint;
            pointReceived = true;
        } else
        {
            player.GetComponent<Player>().BlockedPoint();
        }

    }

    public void ResetSafeCollider()
    {
        GetComponent<SpriteRenderer>().sprite = availablePoint;
        pointReceived = false;
    }
}
