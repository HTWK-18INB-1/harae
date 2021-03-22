using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject player;

    public float speed;
    public float minDistance;

    public Animator animator;
    
    public float attackRange = 1f;
    public Transform attackPoint;
    public int damage;
    public float attackSpeed = 5f;
    private float nextAttack= 0f;

    public LayerMask playerLayers;

    private bool inDistance = false;
    private bool startAnimation = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            animator.SetBool("startAnimation",true);
            startAnimation = true;
        }

        if(startAnimation){
            fight();
        }

    }

    void moveToPlayer(){    //move to player
        //transform.LookAt(player.transform);
        if(!inDistance){
        Vector3 newPos = new Vector3(player.transform.position.x,0,player.transform.position.z);    

        /* Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
         */
         transform.position = Vector3.MoveTowards(transform.position,newPos,speed * Time.deltaTime);
        }
    }

    void checkHit(){    //hit physics(reduce live)
        Collider[] hitPlayer=Physics.OverlapSphere(attackPoint.position,attackRange,playerLayers); //size = 1
        foreach(Collider enemy in hitPlayer){
            Debug.Log("we hit it " + enemy.name);
            enemy.GetComponent<playerCombat>().takeDamage(damage);
        }
    }

    void checkRange(){  //check if enemy inRange
        
        float dist = Vector3.Distance(player.transform.position,transform.position);
        if(dist < minDistance) {
            if(Time.time > nextAttack){ //check if attack ready
                inDistance = true;
                nextAttack = Time.time + attackSpeed;
                animator.SetTrigger("meleeAttack");
                if(animator.GetCurrentAnimatorStateInfo(0).IsName("standUp.zombiePunch")){
                    Debug.Log("weiter");
                    checkHit();
                }   
            }
        }

        if(dist >= minDistance) {
            inDistance = false;
        }
    }

    public void fight(){
        
        moveToPlayer();
        checkRange();
         
    }

    

    
}
