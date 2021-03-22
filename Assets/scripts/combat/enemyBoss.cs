using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoss : MonoBehaviour
{
    public GameObject zombie;
    public GameObject spawnAnimation; 
    public GameObject player;
    public Transform attackPoint;
    public LayerMask playerLayers;
    private Animator animator;
    
    private float dist;
    public float minDistance;

    public float health; 
    public float speed;
    public float attackRange = 0.5f;

    private bool startRun=false; 
    private bool inRange=false;
    private bool attackReady = true;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position,transform.position);
        if(dist<=minDistance) {
            inRange = true;
        }
        
        //spawns a Zombie random on map -> who attacks enemy(player)
        if(Input.GetKeyDown(KeyCode.S)){
            spawnZombie();
        }

        //appear of boss
        if(Input.GetKeyDown(KeyCode.A)){        
            if(animator != null){
                animator.SetBool("startBattlecry",true);
            }
        }

        if(Input.GetKeyDown(KeyCode.B)){
            animator.SetTrigger("startRun");
            startRun = true;
        }

        if(startRun){
                runToPlayer();
            } 
        
        if(inRange && attackReady){
            attack();
            animator.SetBool("startBattlecry",false); //when fight began -> stop looping
            
        }
        

    }

    void spawnZombie(){
        Vector3 position = new Vector3(Random.Range(0f,50f),0,Random.Range(-10f,10f));
        Instantiate(spawnAnimation,position,Quaternion.identity);
        Instantiate(zombie,position,Quaternion.identity);
    }

    //connected animation an movement toward player
    /* void runjump()
    {
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
            
    } */

        
        void runToPlayer(){
            if(dist>minDistance)
            {
                Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
                transform.position += transform.forward * speed* Time.deltaTime;
                transform.LookAt(player.transform);
                dist = Vector3.Distance(player.transform.position,transform.position);
            }

            else{
                inRange = true;
                startRun = false;
            }
        }

        void attack(){
            animator.SetTrigger("wipeAttack");
            attackReady = false;
            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position,attackRange,playerLayers);
            foreach(Collider enemy in hitPlayer){
                Debug.Log("He hit the player!");
            }
        }

    }

