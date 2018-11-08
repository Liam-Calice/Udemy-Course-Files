using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public int damage;

    public GameObject explosion;

    public GameObject soundObject;

    public GameObject trail;
    private float timeBtwTrail;
    public float startTimeBtwTrail;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Instantiate(soundObject, transform.position, transform.rotation);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void Update()
    {

        if (timeBtwTrail <= 0) {
            Instantiate(trail, transform.position, Quaternion.identity);
            timeBtwTrail = startTimeBtwTrail;
        } else
        {
            timeBtwTrail -= Time.deltaTime;
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }

        if (other.tag == "boss")
        {
            other.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }

    }


}
