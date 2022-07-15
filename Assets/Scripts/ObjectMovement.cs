using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementDir;
    public float speed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementDir = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = movementDir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector2 differenceVect = transform.position - collision.gameObject.transform.position;
        //float angle = Vector3.Angle(differenceVect, Vector2.up);


        // set new direction based on vector between objects
        movementDir = (transform.position - collision.transform.position).normalized;
    }
}