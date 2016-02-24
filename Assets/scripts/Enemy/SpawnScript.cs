using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    // Variable to store the enemy prefab
    public GameObject melee;
    public GameObject caster;
    public GameObject canon;
    private bool isAccelerated;
    private int whichOne;
   

    // Variable to know how fast we should create new enemies
    public float spawnTime = 1.0f;
    private int numberEnemy = 0;

    void Start()
    {
        // Call the 'addEnemy' function every 'spawnTime' seconds
        InvokeRepeating("addEnemy", spawnTime, spawnTime);
        // Random whichOne = new Random();
    }

    // New function to spawn an enemy
    void addEnemy()
    {
        // Variables to store the X position of the spawn object
        // See image below
        var y1 = transform.position.y - GetComponent<Renderer>().bounds.size.y / 2;
        var y2 = transform.position.y + GetComponent<Renderer>().bounds.size.y / 2;

        // Randomly pick a point within the spawn object
        var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2));

        whichOne = Random.Range(1, 8);
        // Create an enemy at the 'spawnPoint' position
        if (whichOne <= 3)
        {
            Instantiate(melee, spawnPoint, Quaternion.identity);
        } else if (whichOne > 2 && whichOne <= 6)
        {
            Instantiate(caster, spawnPoint, Quaternion.identity);
        }
        else if (whichOne == 7)
        {
            Instantiate(canon, spawnPoint, Quaternion.identity);
        }

        numberEnemy++;
        //AccelerationSpawn
        /*if (numberEnemy >= 10 && isAccelerated == false)
        {
            isAccelerated = true;
            spawnTime = 0.25f;
            Start();
        }*/
    }
}
