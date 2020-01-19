using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float damage;
    public float offset;
    private Transform player;
    public Transform shotPoint;

    public GameObject Explosion;
    public GameObject Bullet;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        
        // Weapon rotation
        Vector3 difference = player.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (timeBtwShots <= 0)
        {
            Instantiate(Explosion, shotPoint.position, Quaternion.identity);
            Instantiate(Bullet, shotPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
