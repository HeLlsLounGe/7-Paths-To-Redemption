using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zitbug : MonoBehaviour
{
    [SerializeField] float EnemySpeed = 5f;
    Rigidbody2D rb2d;
    CircleCollider2D Collider;
    [SerializeField] float Timer = 2;
    float timer1 = 0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        rb2d.velocity = new Vector2(EnemySpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            EnemySpeed = -EnemySpeed;
        }
        if (collision.gameObject.tag == "Player")
        {
            timer1 += Time.deltaTime;
            if (timer1 >= Timer)
            {
                Collider.enabled = true;
            }
        }
    }
}
