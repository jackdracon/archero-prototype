using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//UIObject component applied to views 
public class UIObject : MonoBehaviour
{
    [SerializeField, Tooltip("Game status reference")]
    private GAMESTATUS gStatusReference = GAMESTATUS.TITLE;

    [SerializeField, Tooltip("Stats value")]
    private TMP_Text statsValue;

    //UIObejct visibility
    public void SetVisibility(bool _visible = true)
    {
        this.gameObject.SetActive(_visible);
    }

    //update stats receive from the game
    public void UpdateStats(int _value)
    {
        if(statsValue) 
            statsValue.text = _value.ToString();
    }

    //GameStatus reference access
    public GAMESTATUS GameStatus
    {
        get { return gStatusReference; }
    }
}
