using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(ShootBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet(ActivateEventArgs arg)
    {
        GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = bulletSpawn.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
        Destroy(spawnBullet, 5);
    }

   
}
