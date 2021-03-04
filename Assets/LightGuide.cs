using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGuide : MonoBehaviour
{
    bool[] isMove = new bool[3] {false,false,false};

    public GameObject finalBook;
    public GameObject targetOne;
    public GameObject targetTwo;

    private float movementSpeed = 0.5f;

    Vector3 targetPosition;
    Vector3 currentPosition;
    Vector3 directionOfTravel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)){
            isMove[0] = true;

        }

        if(isMove[0]){
            isMove[1]=moveToDestination(targetOne);
        }

        if(isMove[1]){
            isMove[0]=false;
            isMove[2]=moveToDestination(targetTwo);
        }

        if(isMove[2]){
            isMove[1]=false;
            moveToDestination(finalBook);
        }
    
        
    }

    bool moveToDestination(GameObject destination){
        targetPosition = destination.transform.position; // Get position of object B
        currentPosition = this.transform.position; // Get position of object A
        directionOfTravel = targetPosition - currentPosition;
        directionOfTravel.y = directionOfTravel.y;//+3
        
        if (Vector3.Distance(currentPosition, targetPosition) > 0.5f)
        {
            this.transform.Translate(
                (directionOfTravel.x * movementSpeed * Time.deltaTime),
                (directionOfTravel.y * movementSpeed * Time.deltaTime),
                (directionOfTravel.z * movementSpeed * Time.deltaTime));
            return false;
         }

        else {
            return true;
        }
    }
}
