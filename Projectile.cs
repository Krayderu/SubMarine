using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    
    public GameObject destroyEffect;
        // Temps limité du projectile
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
        // Direction du projectile
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
        // Destruction du projectile
    void DestroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
