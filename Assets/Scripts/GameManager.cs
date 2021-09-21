using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public enum GameStates
    {
        playing,
        menu,
        paused
    }

    public static GameStates gt;

   
    #endregion

    #region Functions

    #endregion

    void Start()
    {
        Application.targetFrameRate = 60;//Android target FPS
    }

    void FixedUpdate()
    {
        switch (gt)
        {
            case GameStates.playing:
                break;
            case GameStates.menu:
                break;
            case GameStates.paused:
                break;
            default:
                break;
        }
    }

}
