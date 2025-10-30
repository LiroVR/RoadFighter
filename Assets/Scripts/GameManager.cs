using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public float timer = 0f;
    public float endTime = 60f;
    public bool timeIsUp = false;

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
    }
}
