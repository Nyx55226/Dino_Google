using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float jumpForce = 8.5f;
    private Animator an;

    [SerializeField] private GameObject groundedCheck;
    [SerializeField] private LayerMask layer;
    
    [SerializeField] private AudioSource audioJump;
    [SerializeField] private AudioSource audioLand;
    [SerializeField] private AudioSource audioDie;

    private bool isStarted = false;

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundedCheck.transform.position, 0.2f,layer);
    }

    private void Awake()
    {
        an = GetComponent<Animator>();
    }
    

    public void jump(InputAction.CallbackContext input)
    {
        if (isGrounded())
        {
            rb.linearVelocityY = jumpForce;
            an.SetBool("isJump",true);
            audioJump.Play();
        }

        if (input.canceled && rb.linearVelocityY>0f)
            rb.linearVelocityY = rb.linearVelocityY * 0.3f;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("grounder"))
        {
            an.SetBool("isJump",false);
            if (isStarted)
                audioLand.Play();
            else
                isStarted = true;
        }

        if (other.gameObject.CompareTag("cactus"))
        {
            an.SetBool("isDead",true);
            audioDie.Play();
            Time.timeScale = 0f;
        }
    }
}
