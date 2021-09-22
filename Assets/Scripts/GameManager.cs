using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] GameObject character;
    CharacterProperties MainProperties;
    public enum GameStates
    {
        playing,
        menu,
        paused
    }

    [SerializeField]public static GameStates gt;

    public enum GameModes
    {
        adventure,
        freeroad
    }

    public static GameModes gms;
    #endregion

    #region Functions

    #endregion

    void Start()
    {
        Application.targetFrameRate = 60;//Android target FPS
        MainProperties = character.GetComponent<CharacterProperties>();
    }

    void FixedUpdate()
    {
        if (GameManager.gt == GameManager.GameStates.playing)
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
            switch (gms)
            {
                case GameModes.adventure:
                    break;
                case GameModes.freeroad:
                    break;
                default:
                    break;
            }
        }
    }

    void RunTime()
    {

    }

}
