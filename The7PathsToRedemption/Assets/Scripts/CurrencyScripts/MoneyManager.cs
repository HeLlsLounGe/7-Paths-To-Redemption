using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] int coinsPerPickup = 1;
    bool wasCollected = false;
    [SerializeField] GameObject Parent;
    void Start()
    {
        gameObject.transform.parent = Parent.transform;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToCoins(coinsPerPickup);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
