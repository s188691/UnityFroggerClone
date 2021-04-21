using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour
{
    public GameObject Player;
    public int winCheckpoints = 0;
    public int gameLevel;
    public float playerPoints = 0;
    public string playerPointsString;
    public float playerHeight = -6;
    public GameObject Timer;
    public Text lostPointsText, levelPointsText, winPointsText;

    void Update()
    {
        gameLevel = GetComponent<GameStates>().level;

        if (winCheckpoints == 3 && gameLevel < 3)
        {
            GetComponent<GameStates>().LevelWon();
            CheckpointReset();
        }
        
        if (gameLevel == 3)
        {
            GetComponent<GameStates>().GameWon();
            CheckpointReset();
        }

        if(Player.GetComponent<Transform>().position.y > playerHeight)
        {
            playerHeight += 1;
            playerPoints += 10;
        }

        playerPointsString = playerPoints.ToString("F0");

        lostPointsText.text = "Points: " + playerPointsString;
        levelPointsText.text = "Points: " + playerPointsString;
        winPointsText.text = "Points: " + playerPointsString;
        
    }
    public void CheckpointReceived()
    {
        winCheckpoints += 1;
        playerPoints += Timer.GetComponent<Timer>().timeRemaining;
    }

    public void CheckpointReset()
    {
        winCheckpoints = 0;
    }
    public void PlayerPointsReset()
    {
        playerPoints = 0;
    }
}
