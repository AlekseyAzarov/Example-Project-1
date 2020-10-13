using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator), typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] jumpSprites = new Sprite[2];

    private Animator animator;
    private float speed = 5f, jump = 3f;
    private bool isOnGround;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            MovePlayer(-1, true);
        else if (Input.GetKey(KeyCode.D))
            MovePlayer(1, false);
        else
            animator.SetBool("IsRunning", false);

        if (Input.GetKey(KeyCode.Space) && isOnGround)
            Jump();

        if (isOnGround == false)
        {
            ObjectInAir();
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        else
        {
            animator.enabled = true;
            GetComponent<Rigidbody2D>().gravityScale = 0.01f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformScript>())
            isOnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformScript>())
            isOnGround = false;
    }

    private void MovePlayer(int direction, bool isLeft)
    {
        if (isOnGround)
        {
            GetComponent<SpriteRenderer>().flipX = isLeft;

            //transform.Translate(Vector2.right * speed * direction);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * direction, ForceMode2D.Force);

            animator.SetBool("IsRunning", true);
        }
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }

    private void ObjectInAir()
    {
        float velocity = GetComponent<Rigidbody2D>().velocity.y;

        animator.enabled = false;

        if (velocity > 0)
            GetComponent<SpriteRenderer>().sprite = jumpSprites[0];
        else
            GetComponent<SpriteRenderer>().sprite = jumpSprites[1];
    }
}
