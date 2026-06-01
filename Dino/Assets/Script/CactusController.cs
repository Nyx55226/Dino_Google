using UnityEngine;

public class CactusController : MonoBehaviour
{
    [SerializeField] private GameObject[] cactus;

    private float time_=0;
    private int randomNumber = 0;
    private Vector2 positionCactus;
    private const float maxSpawnTime = 3.5f;
    private const float minSpawnTime = 2.5f;
    

    // Update is called once per frame
    void Update()
    {
        time_ += Time.deltaTime;
        if (time_ >= Random.Range(minSpawnTime,maxSpawnTime))
        {
            time_ =0;
            randomNumber = Random.Range(0,3);
            positionCactus= new Vector2((float)9.92, (float)-1.67);
            Instantiate(cactus[randomNumber],positionCactus, Quaternion.identity);
            
        }
    }
    
}
