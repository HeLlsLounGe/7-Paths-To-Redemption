using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int PlayerLives = 1;
    [SerializeField] public int Cash = 0;
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
    public bool Pistol = false;
    public bool Homing = false;
    public bool Shotgun = false;
    public bool BigGun = false;
    public bool FastGun = false;

    void Start()
    {
        CashText.text = Cash.ToString();
    }
    private void Update()
    {
        if (Pistol||Homing||Shotgun||BigGun||FastGun)
        {
            Time.timeScale = 1f;
        }else
        {
            //Time.timeScale = 0f;
        }
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
        pLevel = 1;
    }
    public void hUpg()
    {
        hLevel = 1;
    }
    public void sUpg()
    {
        sLevel = 1;
    }
    public void bUpg()
    {
        bLevel = 1;
    }
    public void fUpg()
    {
        fLevel = 1;
    }
    public void NextRoom()
    {
        if (rooms.Count > 0)
        {
            int r = Random.Range(0, rooms.Count);
            SceneManager.LoadScene(rooms[r]);
            rooms.RemoveAt(r);
        }
        else
        {
            SceneManager.LoadScene("BossRoom");
        }
    }
    public void PT()
    {
        Pistol = true;
        Homing = false;
        Shotgun = false;
        BigGun = false;
        FastGun = false;
    }
    public void HT()
    {
        Homing = true;
        Pistol = false;
        Shotgun = false;
        BigGun = false;
        FastGun = false;
    }
    public void ST()
    {
        Shotgun = true;
        Pistol = false;
        Homing = false;
        BigGun = false;
        FastGun = false;
    }
    public void BT()
    {
        BigGun = true;
        Pistol = false;
        Homing = false;
        Shotgun = false;
        FastGun = false;
    }
    public void FT()
    {
        FastGun = true;
        Pistol = false;
        Homing = false;
        Shotgun = false;
        BigGun = false;
    }
}
