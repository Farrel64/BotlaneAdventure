using UnityEngine;
using System.Collections;

public class casterMinion : MonoBehaviour
{


    public Transform target;
    private bool isInPosition = false;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    /// Object speed
    /// </summary>
    /// 
    public int hp = 1;
    public float minDistX = 4;

    public Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(1, 0);

    private Vector2 movement;

    void Update()
    {

        if (transform.position.x > minDistX)
        {
            GetComponent<Rigidbody2D>().velocity = movement;
        }
        else
        {
            if (isInPosition == false)
            {
                StartCoroutine(waitOneSec());
                isInPosition = true;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            Attack(true);

        }

        mouvement();

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

    }

    IEnumerator cooldownShoot()
    {
        yield return new WaitForSeconds(shootCooldown);
    }

    IEnumerator waitOneSec()
    {
        yield return new WaitForSeconds(1);
    }
    
    public void mouvement()
    {
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);

        
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
    }

    public Transform shotPrefab;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 0.25f;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

    private float shootCooldown;

   

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
         
           shootCooldown = shootingRate;
            

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            shotscript shot = shotTransform.gameObject.GetComponent<shotscript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                //  move.direction = target.position; // towards in 2D space is the right of the sprite
                move.direction = new Vector2(-1,0);
            }
        }
    }

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }


}
