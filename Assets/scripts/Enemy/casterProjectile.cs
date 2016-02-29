using UnityEngine;
using System.Collections;

public class casterProjectile : MonoBehaviour {

    public Transform target;
    private Vector2 direction;
    private Vector2 movement;
    public int moveSpeed;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        direction = target.position;


        movement = new Vector2(
               -4 /*Différence maximale entre y*/,
               direction.y - transform.position.y);


        movement = Vector2.ClampMagnitude(movement, moveSpeed);

        GetComponent<Rigidbody2D>().velocity = movement;

    }


    void Update()
    {

        if (transform.position.x < -0.5)
        {
            Destroy(gameObject);
        }
    }
}