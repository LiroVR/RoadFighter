using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMoveRight : ICommand
{
    private Transform _transform;
    private float _moveDistance;

    private Rigidbody2D rb;

    void Start()
    {
        rb = FindObjectOfType<PlayerController>().rb;
    }

    public CommandMoveRight(Transform transform, float moveDistance) //Fix to physics based movement
    {
        _transform = transform;
        _moveDistance = moveDistance;
    }

    public override void Execute()
    {
        _transform.Translate(Vector3.right * _moveDistance); //Change to rb.AddForce for physics based movement
    }
}

