using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Buttons : MonoBehaviour
{
    public void ExitGame()
    {
        //call save functions
        Application.Quit();
    }
    public void FreeRoad()
    {
        //this method do not exist until... today
    }
    public void Adventure()
    {
        GameManager.gt = GameManager.GameStates.playing;
    }
    public void BacktoMenu()
    {
        GameManager.gt = GameManager.GameStates.menu;
    }
}
