using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy2 : MonoBehaviour
{
    public float moveSpeed2 = 3f;
    private Rigidbody2D ERB2;
    private Animator Eanim2;
    private bool moveLeft2;

    public Transform down_Collision;
  
    private bool Move;
    private bool Sleep;
    public LayerMask PlayerLayer;

    private void Awake()
    {
        ERB2 = GetComponent<Rigidbody2D>();
        Eanim2 = GetComponent<Animator>();
    }
    void Start()
    {
        moveLeft2 = true;
        Move = true;

    }

    void Update()
    {
        if (Move)
        {
            if (moveLeft2)
            {
                ERB2.linearVelocity = new Vector2(-moveSpeed2, ERB2.linearVelocity.y);
            }
            else
            {
                ERB2.linearVelocity = new Vector2(moveSpeed2, ERB2.linearVelocity.y);
            }
        }
        CheckCollision();
    }
    void CheckCollision()
    {
       
        if (!Physics2D.Raycast
            (down_Collision.position, Vector2.down, 0.9f))
        {
            ChangeDirection();
        }
    }
    void ChangeDirection()
    {
        moveLeft2 = !moveLeft2;
        Vector3 tempScale = transform.localScale;
        if (moveLeft2)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }
        transform.localScale = tempScale;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); 
        }
    }
}