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
    Animator MyAnimator;
    float Atk1 = 0;
    float Atk2 = 10;
    float DMG = 0;
    float DestroyTime = 0;

    bool IsAlive = true;
    private void Start()
    {
        MyAnimator = GetComponent<Animator>();
        Atk1 += Time.deltaTime;
        Atk2 += Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Health -= DMG;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(DamageSound);
            Destroy(other);
        }
    }
    void Update()
    {
        DMG = FindObjectOfType<Weapon1>().BulletDmg;
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
            Atk1 = 0;
            //attack and anim
        }
        if (Atk2 >= Atk2Timer)
        {
            Atk2 = 0;
            //attack2 and anim
        }
    }
}
