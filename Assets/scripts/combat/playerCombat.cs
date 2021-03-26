using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class playerCombat : MonoBehaviour
{
    public float damage;
    public float range ;
    public GameObject shootParticleObject;
    private ParticleSystem shootParticle;
    public float speed;
    public int maxHealth;
    private int currentHealth;

    public InputDevice inputController;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        shootParticle = shootParticleObject.GetComponent<ParticleSystem>();
    }
    

    // Update is called once per frame
    void Update()
    {
        //shoot on enemy
        if(inputController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue){
            shoot();
        }
        
    }

    private void shoot()
    {
        RaycastHit hit;
        shootParticle.Play();
        if(Physics.Raycast(this.transform.position,this.transform.forward,out hit,range)){
            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(target);
            if(target != null) {
                target.takeDamage(damage);
                Debug.Log("TREFFER!");
                
            }
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

    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void Die(){
        //die animation

        //disable enemys
        PauseGame();

    }
}
