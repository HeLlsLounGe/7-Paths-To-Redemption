using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float ChaseDistance = 5f;
    [SerializeField] float MoveSpeed = 5f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Vector3 PlayerPosition = player.transform.position;
        Vector3 MoveDirection = PlayerPosition - transform.position;
        if (MoveDirection.magnitude <= ChaseDistance)
        {
            MoveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = MoveDirection * MoveSpeed;
        }
    }
}
