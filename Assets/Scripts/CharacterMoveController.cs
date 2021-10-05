using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{

    public float jumpForce = 7.0f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        setupRef();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * jumpForce * 2, ForceMode2D.Impulse);
        }
        updateAnim();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void setupRef()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void updateAnim()
    {
        anim.SetBool("isJumping", !isGrounded);
        anim.SetFloat("verticalVelocity", rb.velocity.y);
    }
}
