using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float jumpForce = 12.5f;
    private Animator an;
    [SerializeField] private InputActionAsset playerInput;

    [SerializeField] private GameObject groundedCheck;
    [SerializeField] private LayerMask layer;
    
    [SerializeField] private AudioSource audioJump;
    [SerializeField] private AudioSource audioLand;
    [SerializeField] private AudioSource audioDie;

    [SerializeField] private Canvas canvasOverlay;
    [SerializeField] private GameObject writing;

    [SerializeField] private TextMeshProUGUI record;

    private bool isStarted = false;

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundedCheck.transform.position, 0.5f,layer);
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
            rb.linearVelocityY *= -0.5f;

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
            writing.SetActive(true);
            canvasOverlay.enabled = true;
            playerInput.FindActionMap("Player").Disable();

            if (ManagerUI.score > ManagerUI.record)
            {
                ManagerUI.record = ManagerUI.score;
                PlayerPrefs.SetInt("record",ManagerUI.record);
                PlayerPrefs.Save();
            }
            record.text = PlayerPrefs.GetInt("record").ToString();
        }
    }
}
