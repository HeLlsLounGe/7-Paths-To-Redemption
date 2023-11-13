using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belphegore : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float MoveSpeed = 3f;
    [SerializeField] float Health = 150f;
    [SerializeField] GameObject prefab;

    bool IsAlive = true;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

        }
    }
    void Update()
    {
        if (Health < 1)
        {
            IsAlive = false;
        }
        if (IsAlive == true)
        {
            Vector3 PlayerPosition = player.transform.position;
            Vector3 MoveDirection = PlayerPosition - transform.position;

            MoveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = MoveDirection * MoveSpeed;
        }
        else
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
