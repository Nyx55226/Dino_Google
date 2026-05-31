using UnityEngine;

public class CactusController : MonoBehaviour
{
    [SerializeField] private GameObject[] cactus;

    private const float spawnTime=2.5f;

    private float time_=0;
    private int randomNumber = 0;
    private Vector2 positionCactus;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time_ += Time.deltaTime;
        if (time_ >= spawnTime)
        {
            time_ -= spawnTime;
            randomNumber = Random.Range(0,3);
            Debug.Log(randomNumber);
            positionCactus= new Vector2((float)9.92, (float)-1.67);
            Instantiate(cactus[randomNumber],positionCactus, Quaternion.identity);
            
        }
    }
    
}
