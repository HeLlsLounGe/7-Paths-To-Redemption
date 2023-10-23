using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FliiesScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float Health = 1f;

    bool IsAlive = true;

    void Update()
    {
        Vector3 PlayerPosition = player.transform.position;
        Vector3 MoveDirection = PlayerPosition - transform.position;
        
        MoveDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = MoveDirection * MoveSpeed;
    }
}
