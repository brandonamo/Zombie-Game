using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float range = 100f;
    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.Paused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }



    void Shoot()
    {
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            //Debug.Log(hit.transform.name);
            Zombie Zom = hit.transform.GetComponent<Zombie>();
            if (Zom && Zom.Die())
            {
                GameManager.Instance.CurrentKills++;
            }
        }
    }
}
