using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D ERB;
    private Animator Eanim;
    private bool moveLeft;

    public Transform down_Collision;
    public Transform top_Collision;
    private bool Move;
    private bool Sleep;
    public LayerMask PlayerLayer;

    private void Awake()
    {
        ERB = GetComponent<Rigidbody2D>();
        Eanim = GetComponent<Animator>();
    }
    void Start()
    {
        moveLeft = true;
        Move = true;

    }

    void Update()
    {
        if (Move)
        {
            if (moveLeft)
            {
                ERB.linearVelocity = new Vector2(-moveSpeed, ERB.linearVelocity.y);
            }
            else
            {
                ERB.linearVelocity = new Vector2(moveSpeed, ERB.linearVelocity.y);
            }
        }
        CheckCollision();
    }
    void CheckCollision()
    {
        Collider2D topHit = Physics2D.OverlapCircle
                (top_Collision.position, 0.2f, PlayerLayer);
        if (topHit != null)
        {
            if (topHit.gameObject.tag == "Player")
            {
                if (!Sleep)
                {
                    topHit.gameObject.GetComponent
                            <Rigidbody2D>().linearVelocity = new Vector2(topHit.gameObject.GetComponent
                            <Rigidbody2D>().linearVelocity.x, 10f);
                    Move = false;
                    ERB.linearVelocity = new Vector2(0, 0);
                    Eanim.Play("E_Sleep");
                    Sleep = true;
                }
            }
        }
        if (!Physics2D.Raycast
            (down_Collision.position, Vector2.down, 0.9f))
        {
            ChangeDirection();
        }
    }
    void ChangeDirection()
    {
        moveLeft = !moveLeft;
        Vector3 tempScale = transform.localScale;
        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }
        transform.localScale = tempScale;
    }
}