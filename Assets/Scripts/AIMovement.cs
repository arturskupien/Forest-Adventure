using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    Vector3 currentVelocity = Vector3.zero;
    float path;
    public float rangeStart;
    public float rangeEnd;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        path = -1f;
    }


    void Update()
    {
        if (rigidBody.position.x < rangeStart)
        {
            path = 1f;
            gameObject.transform.localScale = new Vector3(-1f,1f,1f);
        }
        else if (rigidBody.position.x > rangeEnd)
        {
            path = -1f;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        Vector3 targetVelocity = new Vector2(path, 0f);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, 0.05f);

    }
}
