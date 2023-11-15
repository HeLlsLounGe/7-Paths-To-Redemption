using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zitbug : MonoBehaviour
{
    [SerializeField] float EnemySpeed = 5f;
    [SerializeField] float EnemyHealth = 4f;
    [SerializeField] GameObject prefab;
    Rigidbody2D rb2d;
    CircleCollider2D Collider;
    [SerializeField] float Timer = 2;
    Animator MyAnimator;
    bool moveAllowed = true;
    float PlayerDMG = 0;
    void Start()
    {
        MyAnimator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        PlayerDMG = FindObjectOfType<Weapon1>().BulletDmg;
        if (moveAllowed)
        {
            rb2d.velocity = new Vector2(EnemySpeed, 0f);
        }else
        {
            rb2d.velocity = new Vector2(.0001f, 0);
        }
        if (EnemyHealth < 1)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            EnemySpeed = -EnemySpeed;
        }
        if (other.gameObject.tag == "Player")
        {
            moveAllowed = false;
            MyAnimator.SetTrigger("Atk");
            Invoke("EnableTrigger", Timer);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            EnemyHealth -= PlayerDMG;
        }
    }
    void EnableTrigger()
    {
        Collider.enabled = true;
        Destroy(gameObject, .1f);
    }
}
