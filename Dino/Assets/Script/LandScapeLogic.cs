using System;
using Unity.VisualScripting;
using UnityEngine;

public class LoadScape : MonoBehaviour
{
    [SerializeField] private GameObject b;
    private float width;
    [SerializeField] private float speed;
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x-0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -18.2)
        {
            transform.position = new Vector2(b.transform.position.x + width, transform.position.y);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * (speed * Time.fixedDeltaTime));
    }
}
