using Unity.VisualScripting;
using UnityEngine;

public class groundLogic : MonoBehaviour
{
    [SerializeField] private GameObject b;

    [SerializeField] private float velocity;

    private float width;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * velocity * Time.fixedDeltaTime);
        if (transform.position.x <= -27.64)
        {
            width = GetComponent<SpriteRenderer>().bounds.size.x - 0.2f;
            transform.position = new Vector2(b.transform.position.x+width,b.transform.position.y) ;
        }
    }
}
