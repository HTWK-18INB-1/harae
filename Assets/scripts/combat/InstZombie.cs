using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstZombie : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float minDistance;
    public Animator animator;
    bool inDistance = false;
    // Start is called before the first frame update
    void Start()
    {
        player = player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(!inDistance){
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
            Vector3 pos = transform.position;
            pos.y = 1;
            transform.position = pos;
        }
        
        Vector3 vectorToTarget = GameObject.FindWithTag("Player").transform.position - transform.position;
        vectorToTarget.y = 0;
        float dist = vectorToTarget.magnitude;
        if(dist < minDistance) {
            animator.SetTrigger("meleeAttack");
            inDistance = true;
            
        }

        if(dist >= minDistance) {
            animator.SetBool("inRange",false);
            inDistance = false;
        }
    }
}
