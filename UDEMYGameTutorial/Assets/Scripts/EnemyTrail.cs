using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrail : MonoBehaviour {

    public GameObject trail;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    private void Update()
    {
        if (timeBtwSpawn <= 0) {
            Instantiate(trail, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        } else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
