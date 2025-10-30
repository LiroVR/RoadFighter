using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private float spawnMinX, spawnMaxX;
    [SerializeField] private float spawnRate = 2f, nextSpawn = 0f, spawnRateMin = 0.5f, spawnRateMax = 2f;
    [SerializeField] private GameObject npcPrefab;
    public float despawnY = -10f, speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (Time.time >= nextSpawn)
        {
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            nextSpawn = Time.time + spawnRate;
            spawnNPC();
        }
    }

    private void spawnNPC()
    {
        float spawnX = Random.Range(spawnMinX, spawnMaxX);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, transform.position.z);
        Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
    }
}
