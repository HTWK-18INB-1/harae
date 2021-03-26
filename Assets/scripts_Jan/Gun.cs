using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Gun : MonoBehaviour {
    public float damage;
    public float range;
    public ParticleSystem shootParticle;
    public float speed;
    public GameObject shootParticleObject;
    public Transform sphere;




    public InputDevice inputController;



    /*
    void Start() {
        shootParticle = shootParticleObject.GetComponent<ParticleSystem>();
    }

    public void shoot() {
        RaycastHit hit;
        shootParticle.Play();
        Debug.Log("Gedrückt!");
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, range)) {
            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(target);
            if(target != null) {
                target.takeDamage(damage);
                Debug.Log("TREFFER!");

            }
        }
    }
    */

    public void Fire() {
        RaycastHit hit;
        GameObject spawnedBullet = Instantiate(shootParticleObject, sphere.position, sphere.rotation);
        //spawnedBullet.GetComponent<Rigidbody>().velocity = speed * sphere.forward;
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, range)) {
            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(target);
            if(target != null) {
                target.takeDamage(damage);
                Debug.Log("TREFFER!");

            }
        }

        Destroy(spawnedBullet, 2);
    }

}
