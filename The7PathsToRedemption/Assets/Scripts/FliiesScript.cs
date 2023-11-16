using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FliiesScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float Health = 1f;
    [SerializeField] GameObject prefab;
    float PlayerDMG = 0;

    bool IsAlive = true;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        PlayerDMG = FindObjectOfType<Weapon1>().BulletDmg;
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
        }else
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Health -= PlayerDMG;
        }
    }
}
