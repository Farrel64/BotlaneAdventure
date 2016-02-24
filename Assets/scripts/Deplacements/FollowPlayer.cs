using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FollowPlayer : MonoBehaviour {


    public Transform target = GameObject.FindWithTag ("Player").transform;
    public float moveSpeed = 3;
    public float MinDist = 2;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Chase();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Chase()
    {
        if (transform.position.x > 2)
        {
            float movementDistance = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementDistance);
        }
    }
}

