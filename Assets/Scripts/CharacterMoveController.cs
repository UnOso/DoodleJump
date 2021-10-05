using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{

    public float moveSpeed = 7.0f;
    public float jumpForce = 7.0f;

    private float boundaries = 2.0f;
    private float baseSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        SetupRef();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * jumpForce * 2, ForceMode2D.Impulse);
        }
        UpdateAnim();
        MoveChar();
        ClampPosition();
    }

    private void LateUpdate()
    {
        DontMoveWhenGrounded();
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

    private void DontMoveWhenGrounded()
    {
        if (isGrounded)
            moveSpeed = 0.0f;
        else
            moveSpeed = baseSpeed;
    }

    private void ClampPosition()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -boundaries, boundaries), transform.position.y);
    }

    private void MoveChar()
    {
        float dirX = Input.acceleration.x * moveSpeed;
        float h = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(dirX + h, rb.velocity.y);
    }

    private void SetupRef()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        baseSpeed = moveSpeed;
    }

    private void UpdateAnim()
    {
        anim.SetBool("isJumping", !isGrounded);
        anim.SetFloat("verticalVelocity", rb.velocity.y);
    }
}
