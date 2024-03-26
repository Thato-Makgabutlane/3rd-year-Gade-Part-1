using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Vector3 offset;
    [SerializeField] float ammoInMag;
    public float magSize = 10f;
    float reloadSpeed;
    public float reloadSpeedReset = 2f;
    float fireRate;
    float fireRateRest = 0.70f;
    public float gunlevel;
    private void Start()
    {
        ammoInMag = magSize;
        reloadSpeed = reloadSpeedReset;
        fireRate = fireRateRest;
    }
    void Update()
    {
        shooting();
        AiShooting();
    }
    void shooting()
    {
        fireRate -= Time.deltaTime;
        if(ammoInMag > 0)
        {
            if (Input.GetMouseButtonDown(0) && fireRate <= 0)
            {
                GameObject temp = Instantiate(Bullet, transform.position + offset, Quaternion.identity);
                temp.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 50;
                ammoInMag--;
                fireRate = fireRateRest;
            }
        }
        else
        {
            reloadSpeed -= Time.deltaTime;
            if(reloadSpeed <= 0)
            {
                ammoInMag = magSize;
                reloadSpeed = reloadSpeedReset;
            }
        }
    }
    void AiShooting()
    {
        if (transform.gameObject.CompareTag("Ai"))
        {
            fireRate -= Time.deltaTime;
            if (fireRate <= 0)
            {
                GameObject temp = Instantiate(Bullet, transform.position + offset, Quaternion.identity);
                temp.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 50;
                ammoInMag--;
                fireRate = fireRateRest;
            }
            else
            {
                reloadSpeed -= Time.deltaTime;
                if (reloadSpeed <= 0)
                {
                    ammoInMag = magSize;
                    reloadSpeed = reloadSpeedReset;
                }
            }
        }
    }
}
