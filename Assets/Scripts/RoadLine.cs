using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLine : MonoBehaviour
{

    public float speed = 5f;
    [SerializeField] private float resetY = -10f;
    private LineSpawner lineSpawner;

    // Update is called once per frame

    void Start()
    {
        lineSpawner = FindObjectOfType<LineSpawner>();
    }
    void Update()
    {
        if (transform.position.y < resetY)
        {
            lineSpawner.ResetLine(gameObject);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
