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
        despawnY = npcSpawner.despawnY;
        speed = npcSpawner.speed;
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
