using UnityEngine;
using System.Collections;

public class canonProjectile : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -0.5)
        {
            Destroy(gameObject);
        }
    }
}
