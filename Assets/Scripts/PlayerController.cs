using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    RigidBody2D rb;
    public Vector2 sideForce = (0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sideForce, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sideForce, ForceMode2D.Force);
        }
    }
}
