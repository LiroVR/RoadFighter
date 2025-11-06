using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 sideForce = new Vector2(10f, 0f);
    bool crashed = false;
    bool bumped = false;
    [SerializeField] NPCSpawner spawner;
    [SerializeField] int healthNum = 100;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (crashed == false)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-sideForce, ForceMode2D.Force);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(sideForce, ForceMode2D.Force);
            }

            if (bumped)
            {
                healthNum -= enemyDamage;
                manager.HealthChange(healthNum);
                bumped = false;

                if (healthNum <= 0)
                {
                    crashed = true;

                    spawner.TriggerSpawner();
                    manager.GameOver();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            bumped = true;
        }
    }
}
