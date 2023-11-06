using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;

    public GameObject impactEffect;

    public GameObject player;

    public ParticleSystem muzzleFlash;

    public Camera fpsCam;

    public AudioManager audioMangaer;

   

    public void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            audioMangaer.Play("Gunshots");
            //audioMangaer.AudioLoop("Gunshots");


        }
        else
        {
            audioMangaer.Play("");
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();


        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           AIExample enemy = hit.transform.GetComponent<AIExample>();
            if(enemy != null)
            {
                enemy.takeDamage(damage);
            }

           GameObject impactGO =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
