using System;
using Unity.VisualScripting;
using UnityEngine;

public class CactusMovement : MonoBehaviour
{
    private float speed=3f;
    void Start()
    {
        
    }

    private void Update()
    {
        if(transform.position.x<=-10.13)
            Destroy(gameObject);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * (ManagerUI.Speed(speed) * Time.fixedDeltaTime));
    }
}
