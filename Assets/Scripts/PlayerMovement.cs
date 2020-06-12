using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public CapsuleCollider2D collider;
    public AudioSource audioSource;
    public float movementSpeed = 40f;
    float moveControlls = 0f;
    float climbControlls = 0f;
    float noGravity = 0f;
    float gravity = 1f;
    float animationSpeed = 2f;
    float jumpDirection;
    bool lowGravity = false;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        rigidBody.gravityScale = gravity;
    }

    void Update()
    {
        jumpDirection = rigidBody.velocity.y;

        //Debug.Log("Y velocity: " + jumpDirection);
        //Debug.Log("Is grounded: " + CharacterController2D.m_Grounded);


        if (Lifes.isDead == false)
        {
            moveControlls = Input.GetAxisRaw("Horizontal") * movementSpeed;
            climbControlls = Input.GetAxisRaw("Climb") * movementSpeed / 5;

            animator.SetFloat("Speed", Mathf.Abs(moveControlls));
            animator.SetFloat("jumpingDirection", jumpDirection);
            if (CharacterController2D.m_Grounded == false)
            {
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }

            if (Input.GetButtonDown("Jump") && !lowGravity)
            {
                jump = true;
                //animator.SetBool("isJumping", true);
                /*
                if (jumpDirection > 0)
                {
                    animator.SetFloat("jumpingDirection", jumpDirection);
                }
                else if (jumpDirection < 0)
                {
                    animator.SetFloat("jumpingDirection", jumpDirection);
                }
                */

            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("Restart"))
            {
                Restart();
            }
        }
    }

    void FixedUpdate()
    {
        if (Lifes.isDead == false)
        {
            controller.Move(moveControlls * Time.fixedDeltaTime, false, jump);
            collider.enabled = true;
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.velocity = new Vector3(0f,-0.5f,0f);
            controller.Move(0f, false, jump);
            animator.SetFloat("Speed",0f);
            collider.enabled = false;
            Delay(150);
        }
    }

    public void OnLanding()
    {
        jump = false;
        animator.SetBool("isJumping", jump);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            lowGravity = true;
            rigidBody.gravityScale = noGravity;
            Vector2 climbing = new Vector2(moveControlls / 8f, climbControlls);
            //Debug.Log(climbing);
            rigidBody.velocity = climbing;
            if (climbControlls != 0 && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Climbing"))
            {
                animator.SetBool("isClimbing", true);
                animator.Play("Climbing", -1, 0f);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            lowGravity = false;
            rigidBody.gravityScale = gravity;
            animator.SetBool("isClimbing", false);
        }
    }



    private async void Delay(int delay)
    {
        await Task.Delay(delay);
        if (Lifes.reallyDead == false)
        {
            gameObject.transform.position = new Vector3(0f, 0f, 0f);
            rigidBody.velocity = Vector3.zero;
        }
    }

    void Restart()
    {
        if (Lifes.reallyDead == false)
        {
            gameObject.transform.position = new Vector3(0f, 0f, 0f);
            rigidBody.velocity = Vector3.zero;
        }
    }

}
