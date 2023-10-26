using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float PlayerLives = 3f;
    Vector2 moveInput;

    Rigidbody2D myRigidBody;

    bool IsAlive = true;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (PlayerLives < 1)
        {
            IsAlive = false;
        }
        if (IsAlive)
        {
            Run();
        }else
        {
            Dmg();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemies")
        {
            PlayerLives--;
        }
    }
    void Dmg()
    {
        FindObjectOfType<GameSession>().ProcessPlayerDmg();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * PlayerSpeed, moveInput.y * PlayerSpeed);
        myRigidBody.velocity = playerVelocity;

        bool PlayerHZMoving = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        bool PlayerVCMoving = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
    }
}
