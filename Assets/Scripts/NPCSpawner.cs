using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private float spawnMinX, spawnMaxX;
    [SerializeField] private float spawnRate = 2f, nextSpawn = 0f, spawnRateMin = 0.5f, spawnRateMax = 2f;
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private int maxNPCs = 10, fuelCarSpawnPercent = 5;
    private int currentNPCs = 0, fuelCarRandom = 0, fuelAmount = 25;
    public float despawnY = -10f, speed = 5f;
    private GameObject spawnedNPC;
    public int enemyDamage = 50;
    bool stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (Time.time >= nextSpawn)
        {
            if (currentNPCs >= maxNPCs)
            {
                break;
            }
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            nextSpawn = Time.time + spawnRate;

            if (stopSpawning == false)
            {
                spawnNPC();
            }
        }
    }

    private void spawnNPC()
    {
        float spawnX = Random.Range(spawnMinX, spawnMaxX);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, transform.position.z);
        spawnedNPC = Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
        spawnedNPC.GetComponent<NPCCar>().damage = enemyDamage;
        currentNPCs++;
        SetToFuelCar(spawnedNPC);
    }

    public void RespawnNPC(GameObject npc)
    {
        float spawnX = Random.Range(spawnMinX, spawnMaxX);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, transform.position.z);
        npc.transform.position = spawnPosition;
        SetToFuelCar(npc);
    }

    private void SetToFuelCar(GameObject npc)
    {
        fuelCarRandom = Random.Range(0, 100);
        if (fuelCarRandom <= fuelCarSpawnPercent)
        {
            npc.GetComponent<NPCCar>().fuelCar = true;
            npc.GetComponent<NPCCar>().fuelAmount = fuelAmount;
            npc.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            npc.GetComponent<NPCCar>().fuelCar = false;
            npc.GetComponent<NPCCar>().fuelAmount = 0;
            npc.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void TriggerSpawner()
    {
        stopSpawning = true;
    }
}
