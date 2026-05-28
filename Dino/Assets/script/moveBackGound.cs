using UnityEngine;

public class groundLogic : MonoBehaviour
{
    private Vector2 startPosition = new Vector2();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 3f * Time.deltaTime);
        if (transform.position.x <= -7.8)
        {
            transform.position = startPosition;
        }
    }
}
