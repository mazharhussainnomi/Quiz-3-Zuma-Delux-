using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPreFab;
    public float bulletSpeed = 50;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPreFab, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            
        }
    }
    
}
    
