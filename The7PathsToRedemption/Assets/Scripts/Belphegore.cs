using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belphegore : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float MoveSpeed = 3f;
    [SerializeField] float Health = 150f;
    [SerializeField] GameObject prefab;
    [SerializeField] AudioClip DamageSound;
    [SerializeField] AudioClip Death;
    [SerializeField] float Atk1Timer = 10;
    [SerializeField] float Atk2Timer = 10;
    [SerializeField] float DestroyMeAt = 3;
    BoxCollider2D AOEAttack;
    CapsuleCollider2D Punch;
    Animator MyAnimator;
    bool Attack1 = true;
    float Atk1 = 0;
    float Atk2 = 99;
    float DMG = 0;
    float DestroyTime = 0;
    bool IsAttacking = false;

    bool IsAlive = true;
    private void Start()
    {
        MyAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        AOEAttack = GetComponent<BoxCollider2D>();
        Punch = GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Health -= DMG;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(DamageSound);
            Destroy(other);
        }
    }
    void Update()
    {
        Atk1 += Time.deltaTime;
        Atk2 += Time.deltaTime;
        DMG = FindObjectOfType<Weapon1>().BulletDmg;
        if (Health < 1)
        {
            IsAlive = false;
        }
        if (IsAlive == true && !IsAttacking)
        {
            Vector3 PlayerPosition = player.transform.position;
            Vector3 MoveDirection = PlayerPosition - transform.position;

            MoveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = MoveDirection * MoveSpeed;
        }
        else
        {
            MyAnimator.SetBool("IsAlive", false);
            DestroyTime += Time.deltaTime;
            if (DestroyTime >= DestroyMeAt)
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(Death);
                Instantiate(prefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (Atk1 >= Atk1Timer)
        {
            Debug.Log("should atk");
            Atk1 = 0;
            if (Attack1)
            {
                IsAttacking = true;
                MyAnimator.SetTrigger("Atk2");
                Invoke("A1", 1.5f);
                Attack1 = false;
            }
            else if (!Attack1)
            {
                IsAttacking = true;
                MyAnimator.SetTrigger("Atk1");
                Invoke("A2", .1f);
                Attack1 = true;
            }
        }
    }
    void A1()
    {
        AOEAttack.enabled = true;
        Invoke("Fin1", .1f);
    }
    void A2()
    {
        Punch.enabled = true;
        Invoke("Fin2", 1f);
    }
    void Fin1()
    {
        AOEAttack.enabled = false;
        IsAttacking = false;
    }
    void Fin2()
    {
        Punch.enabled = false;
        IsAttacking = false;
    }
}
