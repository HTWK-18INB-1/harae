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
    bool inDistance = false;

    // Start is called before the first frame update
    void Start()
    {
        Thread.Sleep(2000);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if(!inDistance){
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;

        }
        
        float dist = Vector3.Distance(player.transform.position,transform.position);
        if(dist < minDistance) {
            animator.SetLayerWeight(0,0f);
            animator.SetLayerWeight(1,1f);
            inDistance = true;
            
        }

        if(dist >= minDistance) {
            animator.SetLayerWeight(1,0f);
            animator.SetLayerWeight(0,1f);
            inDistance = false;
        }

    }
}
