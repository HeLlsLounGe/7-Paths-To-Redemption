using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costs : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    public void Pist()
    {
        if (FindObjectOfType<GameSession>().Cash > 50)
        {
            FindObjectOfType<GameSession>().AddToCoins(-50);
            FindObjectOfType<GameSession>().pUpg();
        }
    }
    public void Hom()
    {
        if (FindObjectOfType<GameSession>().Cash > 80)
            FindObjectOfType<GameSession>().AddToCoins(-80);
        FindObjectOfType<GameSession>().hUpg();
    }
    public void Shot()
    {
        if (FindObjectOfType<GameSession>().Cash > 100)
        {
            FindObjectOfType<GameSession>().AddToCoins(-100);
            FindObjectOfType<GameSession>().sUpg();
        }
    }
    public void Big()
    {
        if (FindObjectOfType<GameSession>().Cash > 120)
        {
            FindObjectOfType<GameSession>().AddToCoins(-120);
            FindObjectOfType<GameSession>().bUpg();
        }
    }
    public void Fast()
    {
        if (FindObjectOfType<GameSession>().Cash > 80)
        {

            FindObjectOfType<GameSession>().AddToCoins(-80);
            FindObjectOfType<GameSession>().fUpg();
        }
    }
    public void OnClick()
    {
        canvas.gameObject.SetActive(false);
    }
}
