using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerMovement : MonoBehaviour
{ 
    private GameObject gameObject;
    private Rigidbody2D player;
    private Animator an;
    private const float forcejump=7f;
    [SerializeField] private Transform groundedCheck;
    [SerializeField] private LayerMask groundedLayer;

    public void Start()
    {
        gameObject = GameObject.FindWithTag("Player");
        player = gameObject.GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }

    public void jump()
    {
        if(isGounded())
        {
            an.SetBool("isjump",true);
            player.linearVelocity = new Vector2(player.linearVelocity.x, forcejump);
        }
    }

    private bool isGounded()
    {
        return Physics2D.OverlapCircle(groundedCheck.position, 0.2f, groundedLayer);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("grounded"))
        {
            an.SetBool("isjump",false);
        }
    }
}