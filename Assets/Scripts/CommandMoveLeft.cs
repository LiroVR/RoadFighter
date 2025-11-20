using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMoveLeft : ICommand
{
    private Transform _transform;
    private float _moveDistance;

    private Rigidbody2D rb;

    void Start()
    {
        rb = FindObjectOfType<PlayerController>().rb;
    }

    public CommandMoveLeft(Transform transform, float moveDistance)
    {
        _transform = transform;
        _moveDistance = moveDistance;
    }

    public override void Execute()
    {
        _transform.Translate(Vector3.left * _moveDistance);
    }
}
