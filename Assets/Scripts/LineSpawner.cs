using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private float spawnRate = 1f, nextSpawn = 0f;
    [SerializeField] private NPCSpawner npcSpawner;
    [SerializeField] private int maxLines = 10;
    private int currentLines = 0;
    private GameObject spawnedLine;

    private float lineSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        npcSpawner = FindObjectOfType<NPCSpawner>();
        lineSpeed = npcSpawner.speed*2f;
    }

    // Update is called once per frame
    void Update()
    {
        while (Time.time >= nextSpawn)
        {
            if (currentLines >= maxLines)
            {
                break;
            }
            nextSpawn = Time.time + spawnRate;
            spawnLine();
        }
    }

    private void spawnLine()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        spawnedLine = Instantiate(linePrefab, spawnPosition, Quaternion.identity);
        spawnedLine.GetComponent<RoadLine>().speed = lineSpeed;
        currentLines++;
    }

    public void ResetLine(GameObject line)
    {
        Vector3 resetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        line.transform.position = resetPosition;
    }
    
}
