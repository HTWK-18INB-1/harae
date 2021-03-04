using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour{

    public float damage;
    public float range;
    public float fireRate;

    public Camera fpsCamera;

    public ParticleSystem iceParticle;

    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            fire();
        }
    }
    
    private void fire()
    {
        iceParticle.Play();
        RaycastHit hit;
        Debug.Log("passiert");
        if(Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward,out hit,range)){
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) 
            {
                target.takeDamage(damage);
                //GameObject instGO = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
                //Destroy(instGO,2f);
                
                
            }
            
            
            
        
    
        }
    }



}
