using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    float timeCounter;
    float speed;
    float width;
    float height;
    private MeshRenderer renderer;
    float health = 100f;


    public void takeDamage(float amount){
        health -=amount;

         if(health <=0f){
            Destroy(gameObject);
        }

    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        timeCounter =0;
        speed =3;
        width =4;
        height =4;
        renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        

       
     }

    //Circulat Movement 
    private void circularTransform(float time,float speed,float width,float height) 
    {
        timeCounter += Time.deltaTime * speed;
        float xpos = Mathf.Cos(timeCounter)* width;
        float ypos = Mathf.Sin(timeCounter)* height;
        this.transform.position = new Vector3(xpos,ypos,0);
    }

   
    

    
}
