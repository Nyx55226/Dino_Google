using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagerUI : MonoBehaviour
{
    [SerializeField] private Canvas canvaOverlay;
    [SerializeField] private GameObject GameOverWriting;
    [SerializeField] private Sprite buttonOff;
    [SerializeField] private Button btn;
    

    public static int record;
    public static int score;

    private float time;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    
    



    private void Start()
    {
        record = PlayerPrefs.GetInt("record",0);
        Application.targetFrameRate = 90;
    }

    public void reloadLevel()
    {
        btn.image.sprite = buttonOff;
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        operation.allowSceneActivation = false;
        canvaOverlay.enabled = false;
        GameOverWriting.SetActive(false);
        Time.timeScale = 1f;
        score = 0;
        operation.allowSceneActivation = true;
    }

    private void Update()
    {
        time += Time.deltaTime;
        
        if (time >= 0.3f)
        {
            time = 0;
            score++;
            scoreText.text = score.ToString();
        }
        

    }

    public static float Speed(float speed)
    {
        switch (score)
        {
            case < 50:
                return speed * 1f;
            case < 100:
                return speed * 1.5f;
            case < 150:
                return speed * 1.7f;
            case < 200:
                return speed * 2f;
            case < 400:
                return speed * 3f;
            case < 1000:
                return speed * 4f;
            case < 2000:
                return speed * 5f;
            case < 4000:
                return speed * 10f;
            default:
                return speed * 15f;
        }
    }
}
