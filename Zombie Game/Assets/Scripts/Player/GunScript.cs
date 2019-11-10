using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float range = 100f;
    public Camera fpsCam;
    GameManager Game;

    private void Start()
    {
        Game = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Game.Paused)
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
            if (hit.transform.GetComponent<Zombie>())
            {
                // killcount after a hit
                //{
                UIManager.instance.killcount++;
                UIManager.instance.UpdateKillcounterUI();
                //}
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
