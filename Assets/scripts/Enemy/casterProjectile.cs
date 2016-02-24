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
    }

    void Update()
    {
       movement = new Vector2(
              moveSpeed * -direction.x,
              direction.y - transform.position.y);

        GetComponent<Rigidbody2D>().velocity = movement;

        if (transform.position.x < -0.5)
        {
            Destroy(gameObject);
        }
    }
}