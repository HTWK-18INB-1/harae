using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public float damage;
    public float range ;
    public ParticleSystem fireParticle;
    //public GameObject impactEffect;
    public float speed;
    public int maxHealth;
    private int currentHealth;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //shoot on enemy
        if(Input.GetKeyDown(KeyCode.I)){
            shoot();
            Debug.Log("SCHUSS");
        }

        //Movement
        basicMovement();
        
    }

    private void shoot()
    {
        RaycastHit hit;
        fireParticle.Play();
        if(Physics.Raycast(this.transform.position,this.transform.forward,out hit,range)){
            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(target);
            if(target != null) {
                target.takeDamage(damage);
                //GameObject instGO = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
                //Destroy(instGO,2f);
                Debug.Log("TREFFER!");
                
            }
        }
    }

    private void basicMovement(){
        if(Input.GetKey(KeyCode.RightArrow))
     {
         transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.LeftArrow))
     {
         transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.DownArrow))
     {
         transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
     }
     if(Input.GetKey(KeyCode.UpArrow))
     {
         transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
     }

     if(Input.GetKey(KeyCode.Space))
     {
         transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
     }
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        //hit animation (blood splashes etc.)
        Debug.Log(currentHealth);
        if(currentHealth <=0){
            Die();
        }
    }

    public int getCurrentHealth(){
        return currentHealth;
    }

    public int getMaxHealth(){
        return maxHealth;
    }


    void Die(){
        //die animation
        //disable enemys

        Debug.Log("player died");
    }
}
