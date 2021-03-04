using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private MeshRenderer renderer;
    public float health;
    public bool boss;
    public ParticleSystem deathAnimation;


    public void takeDamage(float amount){
        health -=amount;

         if(health <=0f){
             if(!boss){
                //Particle System 
                Destroy(gameObject);
             }

            else{
                deathAnimation.Play();
                Destroy(gameObject);
            }
            
        }

    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

   
    

    
}
