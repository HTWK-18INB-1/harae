using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public float damage;
    public float range ;

    public Camera fpsCamera;

    public ParticleSystem fireParticle;

    public GameObject impactEffect;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            shoot();
            Debug.Log("SCHUSS");
        }
        
    }

    private void shoot()
    {
        RaycastHit hit;
        fireParticle.Play();
        if(Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward,out hit,range)){
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) {
                target.takeDamage(damage);
                GameObject instGO = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(instGO,2f);
                Debug.Log("TREFFER!");
                
            }
            
            
            
        }
    }
}
