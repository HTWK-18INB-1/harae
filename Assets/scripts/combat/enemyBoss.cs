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
    private float spawnTime = 8f;

    public float health; 
    public float speed;
    public float attackRange;

    private bool startRun=false; 
    private bool inRange=false;
    private bool attackReady,spawnReady = true;

    GameObject light;
    LightGuide lightScript;
    private GameObject bossParticle;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        light = GameObject.Find("helpLight");
        lightScript = light.GetComponent<LightGuide>();
        bossParticle = this.transform.GetChild(2).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position,transform.position);
        if(dist<=minDistance) {
            inRange = true;
        }

        //start spawn animation when light part fisihed
        if(lightScript.isFinished && spawnReady) {
            animator.SetTrigger("standUp");
            enemyAppear();
            spawnReady = false;
        }
        
        //spawns a Zombie random on map -> who attacks enemy(player),every x seconds
        spawnTime -= Time.deltaTime;
        if(spawnTime <0){
            spawnZombie();
            spawnTime = 8f;
        }
        
        

        
        //appear of boss
        animator.SetBool("startBattlecry",true);


        /* animator.SetTrigger("startRun");
        startRun = true;
        

        if(startRun){
                runToPlayer();
            } 
        
        if(inRange && attackReady){
            attack();
            animator.SetBool("startBattlecry",false); //when fight began -> stop looping */
            
        
    }

    

    void spawnZombie(){
        Vector3 position = new Vector3(Random.Range(-50f,60f),0,Random.Range(-45f,45f));
        Instantiate(spawnAnimation,position,Quaternion.identity);
        Instantiate(zombie,position,Quaternion.identity);
    }

        
    void runToPlayer(){
            if(dist>minDistance){
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

        void enemyAppear(){
        if(this.transform.position.y<0){
            bossParticle.GetComponent<ParticleSystem>().Play();
            Vector3 temp = bossParticle.transform.position;
            this.transform.position += new Vector3(0,3*Time.deltaTime,0);
            bossParticle.transform.position = temp;
            }
        }
}

