using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject gameOverScreen, levelWonScreen, GameWonScreen;
    public GameObject Checkpoint1, Checkpoint2, Checkpoint3, Checkpoint4, Checkpoint5, Timer;
    public float levelTime = 30f;
    public float levelSpeed = 3f;
    public int level = 0;
    private string[] cheatCode;
    private int index;

    void Start() 
    {
     // Cheat Code is "wow", user needs to input this in the right order
        cheatCode = new string[] { "w", "o", "w"};
        index = 0;    
    }

    void Update()
    {
        if (Input.anyKeyDown) 
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;    
            }
        }
        if (index == cheatCode.Length) {
            GetComponent<PointsSystem>().winCheckpoints = 3;
            index = 0;
        }
    }

    public void GameOver()
    {
        //Game Over Trigger
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void LevelWon()
    {
        Time.timeScale = 0;
        levelWonScreen.SetActive(true);
        level += 1; 
    }
    public void NextLevel()
    {
        levelWonScreen.SetActive(false);
        Time.timeScale = 1;
        levelTime -= 10f;
        levelSpeed += 0.75f;
        Player.GetComponent<Player>().ResetPosition();
        Checkpoint1.GetComponent<SafeCollider>().ResetSafeCollider();
        Checkpoint2.GetComponent<SafeCollider>().ResetSafeCollider();
        Checkpoint3.GetComponent<SafeCollider>().ResetSafeCollider();
        Checkpoint4.GetComponent<SafeCollider>().ResetSafeCollider();
        Checkpoint5.GetComponent<SafeCollider>().ResetSafeCollider();
    }

    public void RestartGame()
    {
        GameWonScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        levelTime = 30f;
        levelSpeed = 3f;
        level = 0;
        Player.GetComponent<Player>().ResetPosition();
        Player.GetComponent<Player>().health = 3;
        GetComponent<PointsSystem>().CheckpointReset();
        GetComponent<PointsSystem>().PlayerPointsReset();
        Checkpoint1.GetComponent<SafeCollider>().ResetSafeCollider();
        Checkpoint2.GetComponent<SafeCollider>().ResetSafeCollider();
        Checkpoint3.GetComponent<SafeCollider>().ResetSafeCollider();
        Checkpoint4.GetComponent<SafeCollider>().ResetSafeCollider();
        Checkpoint5.GetComponent<SafeCollider>().ResetSafeCollider();

    }

    public void ResetTimer()
    {
        Timer.GetComponent<Timer>().timeRemaining = levelTime;
        Timer.GetComponent<Timer>().timerIsRunning = true; 
    }

    public void GameWon()
    {
        Time.timeScale = 0;
        GameWonScreen.SetActive(true);
        levelWonScreen.SetActive(false);
    }

}
