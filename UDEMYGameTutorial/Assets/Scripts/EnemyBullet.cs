using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    Player playerScript;
    Vector2 targetPosition;

    public float speed;
    public int damage;

    public GameObject effect;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
    }


    private void Update()
    {
         
        if ((Vector2)transform.position == targetPosition)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }

    }

}
