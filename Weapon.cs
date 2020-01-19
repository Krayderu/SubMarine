using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public ScreenShake ScreenShake;
    public GameObject Explosion;

    private float timeBtwShots;
    public float startTimeBtwShots;
      private void Update()
    {
        // Weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        // Handles the Shooting
        if (timeBtwShots <= 0) 
        {

            if (Input.GetMouseButtonDown(0))
            {
            Instantiate(projectile, shotPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;

            Instantiate(Explosion, shotPoint.position, Quaternion.identity);

            StartCoroutine(ScreenShake.Shake(.15f, .2f));


            }
       
        }
         else {
            timeBtwShots -= Time.deltaTime;
        }
    }
}