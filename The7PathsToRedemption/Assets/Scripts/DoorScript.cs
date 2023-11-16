using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Enemies");
        Debug.Log(list.Length);
        if (list.Length==0&&collision.gameObject.tag=="Player") 
        {
            FindObjectOfType<GameSession>().NextRoom(); 
        }
    }
}
