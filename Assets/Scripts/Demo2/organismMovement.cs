using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organismMovement : MonoBehaviour
{
    Vector3 movementDir;
    public float moveSpeed;
    private Vector3 goalPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        movementDir = goalPos - transform.position;
        transform.position += movementDir * moveSpeed * Time.deltaTime;
    }

    void SetGoalPos(Vector3 newPos)
    {
        goalPos = newPos;
    }
}
