using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoss : MonoBehaviour
{
    public GameObject zombie;
    public GameObject spawnAnimation; 
    public GameObject player;
    public Animator animator;

    public float minDistance;
    public float health; 
    public float speed; // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        

        //spawns a Zombie random on map -> who attacks enemy(player)
        if(Input.GetKeyDown(KeyCode.S)){
            spawnZombie();
        }

        bruteForceAttack();

    }

    void spawnZombie(){
        Vector3 position = new Vector3(Random.Range(0f,50f),0,Random.Range(-10f,10f));
        Instantiate(spawnAnimation,position,Quaternion.identity);
        Instantiate(zombie,position,Quaternion.identity);
    }

    void bruteForceAttack()
    {
        Debug.Log("BRUTEFORCE");
            float dist = Vector3.Distance(player.transform.position,transform.position);
            Debug.Log(dist);
            if(dist>minDistance)
            {
                Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
                transform.position += transform.forward * speed* Time.deltaTime;
                animator.SetBool("isInRange",false);
                Debug.Log("NOT IN RANGE");
            }

            if(minDistance >= dist)
            {
                animator.SetBool("isInRange",true);
                Debug.Log("IN RANGE");
            }
    }

        


    }

