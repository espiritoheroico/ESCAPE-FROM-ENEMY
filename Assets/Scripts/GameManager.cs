using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Variables
    public enum Gamemode
    {
        FreeRoad,
        Adventure
    }

    public Gamemode gmode;
    #endregion

    #region Functions

    #endregion

    void Start()
    {
        Application.targetFrameRate = 60;//Android target FPS
    }

    void FixedUpdate()
    {
        switch (gmode)
        {
            case Gamemode.FreeRoad:
                break;
            case Gamemode.Adventure:
                break;
            default:
                break;
        }
    }
}
