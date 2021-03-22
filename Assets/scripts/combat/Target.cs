using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public bool boss;
    private ParticleSystem deathAnimation;


    
    
    void Die(){
        
             if(!boss){
                //Particle System 
                Destroy(gameObject);
             }

            else{
                deathAnimation.Play();
                Destroy(gameObject);
            }
    }

    public void takeDamage(float amount){
        health -=amount;
        if(health <=0f){
            Die();
        }
         

    }

    // Start is called before the first frame update
    void Start()
    {
        deathAnimation = this.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

   
    

    
}
