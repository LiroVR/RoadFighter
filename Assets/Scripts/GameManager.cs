using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float timer = 0f;
    public float endTime = 60f;
    public bool timeIsUp = false;
    public int score = 0;
    private bool gameOver = false;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI healthText;
    [SerializeField] private TMPro.TextMeshProUGUI fuelText;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer == endTime)
        {
            timeIsUp = true;
        }
        else if (gameOver == false)
        {
            score = (int)(timer * 10);
            scoreText.text = "Score: \n" + score.ToString();
        }
    }

    public void HealthChange(int health)
    {
        healthText.text = "Health: \n" + health.ToString();
    }

    public void FuelChange(int fuel)
    {
        fuelText.text = "Fuel: \n" + fuel.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
