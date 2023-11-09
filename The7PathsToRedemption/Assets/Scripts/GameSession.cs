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
    [SerializeField] AudioClip CoinSound;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] List<int> rooms;
    [SerializeField] int LifeFull = 1;
    public int pLevel = 0;
    public int hLevel = 0;
    public int sLevel = 0;
    public int bLevel = 0;
    public int fLevel = 0;

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
        Camera.main.GetComponent<AudioSource>().PlayOneShot(CoinSound);
    }
    public void ProcessPlayerDmg()
    {
        if (PlayerLives > 1)
        {
            TakeLife();
        }else if (PlayerLives <= 1)
        {
            ResetGameSession();
        }
    }void ResetGameSession()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(DeathSound);
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene("Home");
        PlayerLives = LifeFull;
    }void TakeLife()
    {
        PlayerLives --;
    }
    public void pUpg()
    {
        pLevel++;
    }
    public void hUpg()
    {
        hLevel++;
    }
    public void sUpg()
    {
        sLevel++;
    }
    public void bUpg()
    {
        bLevel++;
    }
    public void fUpg()
    {
        fLevel++;
    }
    public void NextRoom()
    {
        if (rooms.Count != 0)
        {
            int r = Random.Range(0, rooms.Count);
            SceneManager.LoadScene(r);
            rooms.RemoveAt(r);
        }
        else
        {
            //load boss
        }
    }
}
