using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdventureMode : MonoBehaviour
{
    #region Variables
    [SerializeField] public Transform startpoint;
    [SerializeField] public Transform endpoint;
    [SerializeField] public GameObject character;
    //
    [SerializeField] private int itenscolected;
    [SerializeField] private int itensinstage;
    [SerializeField] private int timesdefeated;
    [SerializeField] List<GameObject> disableditens = new List<GameObject>();
    //
    [SerializeField] private int points;
    [SerializeField] public float timecounter;
    [SerializeField] List<bool> objectives = new List<bool>();
    [SerializeField] int completedobjectives;
    [SerializeField] bool MainObjective = false;
    #endregion

    #region TextPanels

    #endregion

    void OnEnable()
    {
        timecounter = 0;
        itenscolected = 0;
        timesdefeated = 0;
        MainObjective = false;
        CharactertoStartPoint();
        for (int i = 0; i < disableditens.Count; i++)
        {
            disableditens[i].SetActive(true);
        }
        
        Collect.aPoint += CollectCount;
        OnCollisionWith.OnDefeated += OnPlayerDefeated;

    }

    void Update()
    {
        if (GameManager.gt == GameManager.GameStates.playing && MainObjective == false)
        {
            Timer(Time.deltaTime);
        }
    }
    void ObjectiveCounter()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            if (objectives[i] == true)
            {
                completedobjectives++;
            }
        }
    }

    void EndPoint(Transform a, Transform b)
    {
            MainObjective = true;
            //Reached final map point
            ObjectiveCounter();
    }
    //COUNT GAME TIME
    void Timer(float delta)
    {
        timecounter += delta;
    }
    // COUNT COLLECTED ITENS
    public void CollectCount(string tag)
    {
        if (tag == "collectable")
        {
            itenscolected++;
        }
        else if (tag == "coin")
        {
            points++;
        }

        if (itenscolected == itensinstage)
        {
            objectives.Add(true);
        }
    }

    //QUANDO O PLAYER MORRER
    public void OnPlayerDefeated()
    {
        character.GetComponent<Character_Controller>().ActorDie(true);
        Invoke("CharactertoStartPoint",0.3f);//I HATE USE INVOKE.. BUT
    }

    //RESETAR O PLAYER
    public void CharactertoStartPoint()
    {
        character.transform.position = startpoint.transform.position;
        timesdefeated++;
        character.GetComponent<Character_Controller>().ActorDie(false);
    }
}
