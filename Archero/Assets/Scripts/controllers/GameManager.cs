using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game Status related to 
    private static GAMESTATUS gameStatus;

    //enemis on scene to be killed
    private int enemiesOnScene = 0;

    //How much enemis was killed by the player
    private static int enemiesKill = 0;

    //spawn manager instance on scene
    private SpawnManager spawn_Manager;
    //Player's instance
    private Player player;

    //flag to stop game
    private bool stopGame = false;

    //Ui maanager instance on scene
    private UIManager ui_Manager;

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
        
        ui_Manager = FindObjectOfType<UIManager>();
        
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        TitleGame();

        Enemy.OnDie += UpdateKills;
    }

    private void Update()
    {
        if (gameStatus == GAMESTATUS.INGAMEPLAY)
        {
            if (player)
            {
                if (player.IsDead)
                {
                    stopGame = true;
                    EndGame();
                }
            }
            else
            {
                EndGame();
            }
        }
    }

    //Update the current number of kills
    public void UpdateKills(Enemy _enemy)
    {
        enemiesKill++;
        ui_Manager.UpdateValues(enemiesKill);

        //End game
        if (enemiesKill == enemiesOnScene)
            EndGame();
    }

    //Title screen
    public void TitleGame()
    {
        ui_Manager.SetBlackScreenVisibility(true);
        SetGameStatus(GAMESTATUS.TITLE);
    }

    //Object's creation when start the game and uppdate the status 
    public void StartGame()
    {
        ui_Manager.SetBlackScreenVisibility();
        
        SetGameStatus(GAMESTATUS.INGAMEPLAY);
        
        stopGame = false;

        spawn_Manager.CreateAllEnemies();
        enemiesOnScene = spawn_Manager.GetEnemiesCount;
    }

    //End Game update
    public void EndGame()
    {
        stopGame = true;
        ui_Manager.SetBlackScreenVisibility(true);
        SetGameStatus(GAMESTATUS.END);
    }

    //Set Game Status and apply to ui
    public void SetGameStatus(GAMESTATUS _status)
    {
        if (gameStatus != _status)
            gameStatus = _status;

        ui_Manager.ChangeByGameStatus(gameStatus);
    }

    //Get the current game status
    public GAMESTATUS GetCurrentStatus
    {
        get { return gameStatus; }
    }

    //Is Paused the game
    public bool IsPaused
    {
        get { return stopGame; }
    }

    public void SetEnemiesOnScene(int _enemies)
    {
        enemiesOnScene = _enemies;
    }

    //Singleton's GameManager instance
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    private void OnDestroy()
    {
        Enemy.OnDie -= UpdateKills;   
    }
}

//status
public enum GAMESTATUS 
{ 
    TITLE,
    INGAMEPLAY,
    END
}
