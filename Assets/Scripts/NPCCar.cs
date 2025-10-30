using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCar : MonoBehaviour
{

    [SerializeField] private NPCSpawner npcSpawner;
    private float despawnY = -10f, speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        npcSpawner = FindObjectOfType<NPCSpawner>();
        despawnY = npcSpawner.despawnY;
        speed = npcSpawner.speed;
        //Sets random colour for NPC car
        Renderer carRenderer = GetComponent<Renderer>();
        carRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < despawnY)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
