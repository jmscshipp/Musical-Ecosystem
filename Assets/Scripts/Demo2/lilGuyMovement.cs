using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilGuyMovement : MonoBehaviour
{
    Vector2 posDif;
    public float moveSpeed;
    Vector3 movementDir;
    private Vector3 goalPos;
    private float dirCounter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        dirCounter = dirCounter - Time.deltaTime;
        if (dirCounter <= 0)
        {
            Decide();
            dirCounter = 1;
        }
    }
    void Decide()
    {
        posDif = goalPos - transform.position;
        if (Mathf.Abs(posDif.x) >= Mathf.Abs(posDif.y))
        {
            movementDir = new Vector3(Mathf.Sign(posDif.x), 0, 0);
        }
        else
        {
            movementDir = new Vector3(0, Mathf.Sign(posDif.y), 0);
        }

    }
    void Move()
    {
        transform.position += movementDir * moveSpeed * Time.deltaTime;
    }

    public void SetGoalPos(Vector3 newPos)
    {
        goalPos = newPos;
    }
}

