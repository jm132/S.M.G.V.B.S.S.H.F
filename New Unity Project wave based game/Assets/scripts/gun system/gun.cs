using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    private float nextTimeToFire = 2f;
    public int bullitsLeft = 30;

    // Update is called once per frame
    void Update()
    {
        if (bullitsLeft == 0) reloadgun();

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)

        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if(bullitsLeft>0)  Shoot();
        }
    }
    void Shoot()
    {
        bullitsLeft--;
        muzzleflash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            target target = hit.transform.GetComponent<target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
    void reloadgun()
    {
        Inventory inventory = FindObjectOfType<MyController>().inventory;
        if (inventory.hasAmmo("ar"))
        {
            bullitsLeft = 30;

        }
    }
}
