using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game Status related to 
    private static GAMESTATUS gameStatus;

    //How much enemis was killed by the player
    private static int enemiesKill = 0;

    //spawn manager instance on scene
    private SpawnManager spawn_Manager;

    //instance
    private static GameManager instance;


    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }

        Instance = this;

        spawn_Manager = FindObjectOfType<SpawnManager>();
    }


    //Update the current number of kills
    public void UpdateKills()
    {
        enemiesKill++;
    }

    //Title screen
    public void TitleGame()
    {
        SetGameStatus(GAMESTATUS.TITLE);
    }

    //Object's creation when start the game and uppdate the status 
    public void StartGame()
    {
        SetGameStatus(GAMESTATUS.INGAMEPLAY);
        spawn_Manager.CreatePlayer();
        
    }

    //End Game update
    public void EndGame()
    {
        SetGameStatus(GAMESTATUS.END);
    }

    //Set Game Status
    public void SetGameStatus(GAMESTATUS _status)
    {
        if (gameStatus != _status)
            gameStatus = _status;
    }

    //Singleton's GameManager instance
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }


}

//status
public enum GAMESTATUS 
{ 
    TITLE,
    INGAMEPLAY,
    END
}
