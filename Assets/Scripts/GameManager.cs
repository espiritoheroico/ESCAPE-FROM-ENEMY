using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    //CONTROLERS
    [SerializeField] GameObject character;
    public enum GameStates
    {
        playing,
        paused
    }
    [SerializeField]public static GameStates gt;
    public enum GameModes
    {
        adventure,
        freeroad
    }
    public static GameModes gms;
    //GameOverCanvas
    [SerializeField] GameObject GameOverCanvas;
    #endregion

    #region Functions
    void Start()
    {
        gt = GameStates.paused;
        Application.targetFrameRate = 60;//Android target FPS
        GameOverCanvas.SetActive(false);
        OnCollisionWith.EndGame += GameOver;
    }
    void FixedUpdate()
    {
            switch (gt)
            {
                case GameStates.playing:
                    break;
                case GameStates.paused:
                    break;
                default:
                    break;
            }
            switch (gms)
            {
                case GameModes.adventure:
                //NOT FINISHED
                    break;
                case GameModes.freeroad:
                //NOT FINISHED
                    break;
                default:
                    break;
            }
    }

    #region BUTTONSVOIDS
    public void Playing()
    {
        gt = GameStates.playing;
    }

    public void GameOver()
    {
        gt = GameStates.paused;
        GameOverCanvas.SetActive(true);
    }

    public void Paused()
    {
        gt = GameStates.paused;
    }
    public void ExitGame()
    {
        //call save functions
        Application.Quit();
    }
    #endregion

    #endregion
}
