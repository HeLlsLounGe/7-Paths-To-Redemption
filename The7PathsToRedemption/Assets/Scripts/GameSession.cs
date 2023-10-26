using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int PlayerLives = 1;
    [SerializeField] int Cash = 0;
    [SerializeField] TextMeshProUGUI CashText;
    void Start()
    {
        CashText.text = Cash.ToString();
    }
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void AddToCoins(int cashToAdd)
    {
        Cash += cashToAdd;
        CashText.text = Cash.ToString();
    }
    public void ProcessPlayerDmg()
    {
        if (PlayerLives > 1)
        {
            TakeLife();
        }else
        {
            ResetGameSession();
        }
    }void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene("Home");
        Destroy(gameObject);;
    }void TakeLife()
    {
        PlayerLives --;
    }
}