using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoss : MonoBehaviour
{
    public GameObject zombie;
    public GameObject spawnAnimation; 
    public GameObject player;
    private Animator animator;

    
    public float minDistance;
    public float health; 
    public float speed;

    private bool startRunJump=false; 
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //spawns a Zombie random on map -> who attacks enemy(player)
        if(Input.GetKeyDown(KeyCode.S)){
            spawnZombie();
        }

        if(Input.GetKeyDown(KeyCode.R)){
            if(animator != null){
                //change animation
                animator.SetLayerWeight(0,0);
                animator.SetLayerWeight(1,1);
            }
            
            startRunJump = true;
            
        }

        if(startRunJump){
                runjump();
            }
        

    }

    void spawnZombie(){
        Vector3 position = new Vector3(Random.Range(0f,50f),0,Random.Range(-10f,10f));
        Instantiate(spawnAnimation,position,Quaternion.identity);
        Instantiate(zombie,position,Quaternion.identity);
    }

    void runjump()
    {
            float dist=100;
            if(dist>minDistance)
            {
                Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
                transform.position += transform.forward * speed* Time.deltaTime;
                animator.SetBool("isInRange",false);
                transform.LookAt(player.transform);
                dist = Vector3.Distance(player.transform.position,transform.position);
            }

            else
            {
                animator.SetBool("isInRange",true);
            }
            
    }

        


    }

