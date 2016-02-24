using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class characterControler : MonoBehaviour
{

    Vector3 pos;
    public float maxHp = 5;
    public float currentHp = 5;
    float speed = 4.0f;                         // Speed of movement
    private bool isInvincible = false;
    public float invincibleTimer = 1;
    public GameObject healthBar;

    void Start()
    {
        pos = transform.position;          // Take the initial position
        currentHp = maxHp;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Z) && transform.position == pos && transform.position.y < 4)
        {        // Up
            pos += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos && transform.position.y > 0)
        {        // Down
            pos += Vector3.down;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there

        // 5 - Shooting
        bool shoot = Input.GetKey(KeyCode.Space);
        //shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            FireScript weapon = GetComponent<FireScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }

        // ...
    }

    public void Damage(int damageCount)
    {
        currentHp -= damageCount;
        //calcul des hp de la bar de vie
        float calc_Hp = currentHp / maxHp;
        SetHealthBar(calc_Hp);

        if (currentHp <= 0)
        {
            // Dead!
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("enemy") && isInvincible == false)
        {
            Damage(1);
            isInvincible = true;
            yield return new WaitForSeconds(invincibleTimer);
            isInvincible = false;
            
        }
        if (otherCollider.CompareTag("enemy_shoot") && otherCollider != null)
        {
            if (isInvincible == false)
            {
                Damage(1);
            }
            Destroy(otherCollider.gameObject);
            isInvincible = true;
            yield return new WaitForSeconds(invincibleTimer);
            isInvincible = false;
        }
    }

    public void SetHealthBar(float myHp)
    {
        //myHp value between 0 & 1, 
        healthBar.transform.localScale = new Vector3(myHp, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
