using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI Manager object
public class UIManager : MonoBehaviour
{

    [SerializeField, Tooltip("Black screen on background object")]
    private GameObject blackScreen;

    [SerializeField, Tooltip("Screens that will be used")]
    private UIObject[] screens;

    //Active screen on scene
    private UIObject activeScreen;

    //Singleton's instance
    private static UIManager instance;

    //Change the screen as game status
    public void ChangeByGameStatus(GAMESTATUS _gameStatus)
    {
        foreach(UIObject _screen in screens)
        {
            if (_screen.GameStatus == _gameStatus)
            {
                _screen.SetVisibility(true);
                activeScreen = _screen;
            }
            else
                _screen.SetVisibility(false);
        }
    }

    //Set visibility on black screen object
    public void SetBlackScreenVisibility(bool _visibble = false)
    {
        if (blackScreen)
        {
            blackScreen.SetActive(_visibble);
        }
    }

    //UPdate the values obj scene
    public void UpdateValues(int _value)
    {
        if (activeScreen)
        {
            activeScreen.UpdateStats(_value);
        }
    }

    //UIManager Instance access
    public static UIManager Instance
    {
        get { return instance; }
    }
}