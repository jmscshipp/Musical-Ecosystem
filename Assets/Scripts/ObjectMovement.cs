using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 movementDir;
    public float speed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementDir = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = movementDir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // right / left side
        if (collision.contacts[0].normal == Vector2.right || collision.contacts[0].normal == Vector2.left)
        {
            movementDir = new Vector2(movementDir.x * -1.0f, movementDir.y);
        }

        // up / down
        else if (collision.contacts[0].normal == Vector2.up || collision.contacts[0].normal == Vector2.down)
        {
            movementDir = new Vector2(movementDir.x, movementDir.y * -1.0f);
        }

        // set new direction based on vector between objects
        //movementDir = (transform.position - collision.transform.position).normalized;
    }
}