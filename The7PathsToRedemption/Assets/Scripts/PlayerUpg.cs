using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpg : MonoBehaviour
{
    public void upgradeP()
    {
        FindObjectOfType<GameSession>().pUpg();
        Debug.Log("button hit");
    }
    public void upgradeH()
    {
        FindObjectOfType<GameSession>().hUpg();
    }
    public void upgradeS()
    {
        FindObjectOfType<GameSession>().sUpg();
    }
    public void upgradeB()
    {
        FindObjectOfType<GameSession>().bUpg();
    }
    public void upgradeF()
    {
        FindObjectOfType<GameSession>().fUpg();
    }
}
