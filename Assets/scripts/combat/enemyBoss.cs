using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoss : MonoBehaviour
{
    public GameObject zombie;
    public GameObject spawnAnimation; 
    public Transform attackPoint;
    public LayerMask playerLayers;
    private Animator animator;
    private GameObject player;
    private playerCombat playerScript;
    
    private float dist;
    public float minDistance=10;
    private float spawnTime = 8f;

    public float health=200; 
    public int damage = 40;
    public float speed=10;
    public float attackRange=10;
    public float nextAttack = 2;

    private bool inRange=false;
    public bool attackReady = true;
    public bool spawnReady = true;
    public bool attackFinished = false;

    GameObject light;
    LightGuide lightScript;
    private GameObject bossParticle;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<playerCombat>();
        animator = GetComponent<Animator>();
        light = GameObject.Find("helpLight");
        lightScript = light.GetComponent<LightGuide>();
        bossParticle = this.transform.GetChild(2).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position,transform.position);
        //start spawn animation when light part fisihed
        if(lightScript.isFinished && spawnReady) {
            animator.SetTrigger("standUp");
            enemyAppear();
            
        }
        

        if(!spawnReady){

            //spawns a Zombie random on map -> who attacks enemy(player),every x seconds
            spawnTime -= Time.deltaTime;
            if(spawnTime <0){
                spawnZombie();
                spawnTime = 8f;
            }
            
            if(!attackFinished){        //if attackmode
                if(!inRange){
                animator.SetBool("startRun",true);
                runToPlayer();
                }

                if(inRange){
                    animator.SetBool("startRun",false);
                    attack();
                    attackFinished = true;
                }
            }

            if(attackFinished){
                moveAway();
            }



        }
    }

    

    void spawnZombie(){
        Vector3 position = new Vector3(Random.Range(-40f,50f),0,Random.Range(-40f,40f));
        Instantiate(spawnAnimation,position,Quaternion.identity);
        Instantiate(zombie,position,Quaternion.identity);
    }

        
    void runToPlayer(){
            if(dist>minDistance){
                Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
                transform.position += transform.forward * speed* Time.deltaTime;
                transform.LookAt(player.transform);
                inRange = false;
            }

            else{
                inRange = true;
            }
        }

        void attack(){
            animator.SetTrigger("wipeAttack");

            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position,attackRange,playerLayers);
            foreach(Collider enemy in hitPlayer){
                playerScript.takeDamage(damage);
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
        else {
            animator.SetBool("startBattlecry",true);
            bossParticle.GetComponent<ParticleSystem>().Stop();
            System.Threading.Thread.Sleep(200);
            spawnReady = false;
        }
        }

        void moveAway(){
            Vector3 randomPos = new Vector3(Random.Range(-40f,40f),0,Random.Range(-40f,40f));
            float tempDist = Vector3.Distance(randomPos,transform.position);

            if(tempDist>7) {
                animator.SetBool("startRun",true);
            }

            else {
                animator.SetBool("startRun",false);
                animator.SetBool("startBattlecry",true);
                attackFinished = false;
            }

        }
}

