using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Players_scripts : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;

    [Header("Player Movement Setting")]
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 15f)] public float jumpForce = 8f;

    [Header("Player Animation Setting")]
    public Animator animator;

    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = false;
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.8f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;

    public GameObject canva;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
       HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

       animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));

       if (HorizontalMove < 0 && FacingRight)
       {
           Flip();
       }
       else if (HorizontalMove> 0 && !FacingRight)
        {
           Flip();
        }   
        
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckedGround();

    }
    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void CheckedGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);
        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag =="Enemy")
        {
            speed = 0;
            canva.SetActive(false);
        }

    }
}
