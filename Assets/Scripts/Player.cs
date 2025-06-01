using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        Rigidbody2D PlayerRB;
        public float PSpeed = 15f;
        Animator Panim;
        public Transform groundcheck;
        public LayerMask groundlayer;
        private bool isGround; //piso 
        private bool jumped; //saltó 
        private float jumpPower = 12f;


        void Start()
        {
            PlayerRB = GetComponent<Rigidbody2D>();
            Panim = GetComponent<Animator>();
        }
        void Update()
        {
            CheckIfGrounded();  //revisando suelo
            PlayerJump();
        }

        void FixedUpdate()
        {
            PlayerWalk();
        }
        void PlayerWalk()
        {
            float h = Input.GetAxisRaw("Horizontal");
            if (h > 0)
            {
                PlayerRB.linearVelocity = new Vector2(PSpeed, PlayerRB.linearVelocity.y);
                ChangeDirection(1); //derecha
            }
            else if (h < 0)
            {
                PlayerRB.linearVelocity = new Vector2(-PSpeed, PlayerRB.linearVelocity.y);
                ChangeDirection(-1); //izquierda
            }
            else
            {
                PlayerRB.linearVelocity = new Vector2(0f, PlayerRB.linearVelocity.y); //idle
            }
            Panim.SetInteger("Speed", Mathf.Abs((int)PlayerRB.linearVelocity.x));
        }
        void ChangeDirection(int direction) //espejo
        {
            Vector3 tempScale = transform.localScale;
            tempScale.x = direction; //x
            transform.localScale = tempScale;
        }
        void CheckIfGrounded() //suelo
        {
            isGround = Physics2D.Raycast(groundcheck.position, Vector2.down, 0.2f, groundlayer);
            if (isGround)
            {
                if (jumped)
                {
                    jumped = false;
                    Panim.SetBool("Jump", false);
                }
            }
        }
        void PlayerJump()
        {
            if (isGround)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    jumped = true;
                    PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, jumpPower);
                    Panim.SetBool("Jump", true);
                }
            }
        }
    }
}