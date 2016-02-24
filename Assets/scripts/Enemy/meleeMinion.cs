using UnityEngine;
using System.Collections;

public class meleeMinion : MonoBehaviour {


    public int hp = 1;
    public int damages = 1;
    public bool isEnemy = true;
    public Transform target;
    public float moveSpeed = 3;
    public float MinDist = 2;
    

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Chase();
    }

    void Chase()
    {
        if (transform.position.x > MinDist && transform != null)
        {
            float movementDistance = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementDistance);
        }
    }

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Dead!
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("carreau"))
        {
            Damage(1);
            Destroy(otherCollider.gameObject);
        }
        // Is this a shot?
        /* shotscript shot = otherCollider.gameObject.GetComponent<shotscript>();
         if (shot != null)
         {
                 Damage(shot.damage);
                 // Destroy the shot
                 Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script

         }*/
    }
}
