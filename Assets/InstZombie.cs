using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstZombie : MonoBehaviour
{
    Transform player;
    public float speed;
    public float minDistance;
    public Animator animator;
    bool inDistance = false;
    // Start is called before the first frame update
    void Start()
    {
        bool inDistance = false;
        player = Camera.main.GetComponent<Transform>();
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(!inDistance){
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;

        }
        
        float dist = Vector3.Distance(player.position,transform.position);
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
