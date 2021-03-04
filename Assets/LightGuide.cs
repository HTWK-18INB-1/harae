using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGuide : MonoBehaviour
{
    bool[] isMove = new bool[3] {false,false,false};
    
    public GameObject player;

    public GameObject finalBook;
    public GameObject targetOne;
    public GameObject targetTwo;

    private Light light;
    //private Halo halo;
    private Color startingColor=Color.red;

    private float movementSpeed = 0.5f;

    Vector3 targetPosition;
    Vector3 currentPosition;
    Vector3 directionOfTravel;

    Vector3[] startPosition = new Vector3[3];
    private bool[] firstStart = new bool[3] {true,true,true};
    private float newDistance;
    private float startDistance;


    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        //halo = GetComponent<Halo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)){
            isMove[0] = true;
        }

        if(isMove[0]){
            //isMove[1]=moveToDestination(targetOne);
            if(firstStart[0]){
                startPosition[0] = player.transform.position;
            }
            firstStart[0] = false;
            changeColor(targetOne,startPosition[0]);
        }

        if(isMove[1]){
            isMove[0]=false;
            //isMove[2]=moveToDestination(targetTwo);
            if(firstStart[1]){
                startPosition[1] = player.transform.position;
            }
            firstStart[1] = false;
            changeColor(targetTwo,startPosition[1]);
        }

        if(isMove[2]){
            isMove[1]=false;
            //moveToDestination(finalBook);
            if(firstStart[2]){
                startPosition[2] = player.transform.position;
            }
            firstStart[2] = false;
            changeColor(finalBook,startPosition[2]);
        }

        
    
        
    }

    bool moveToDestination(GameObject destination){
        targetPosition = destination.transform.position; // Get position of object B
        currentPosition = this.transform.position; // Get position of object A
        directionOfTravel = targetPosition - currentPosition;
        directionOfTravel.y = directionOfTravel.y;//+3
        newDistance = Vector3.Distance(currentPosition, targetPosition);
        
        if (newDistance > 0.5f)
        {
            this.transform.Translate(
                (directionOfTravel.x * movementSpeed * Time.deltaTime),
                (directionOfTravel.y * movementSpeed * Time.deltaTime),
                (directionOfTravel.z * movementSpeed * Time.deltaTime));
            return false;
         }

        else {                  // if player grabbed item toFind
            return true;
        }
    }

    void changeColor(GameObject destination,Vector3 startPositionf) {
        targetPosition = destination.transform.position; // Get position of object B
        currentPosition = this.transform.position; // Get position of object A
        newDistance = Vector3.Distance(currentPosition,targetPosition);
        startDistance = Vector3.Distance(startPositionf,targetPosition);

        float ratio = newDistance/(newDistance+startDistance);

        light.color = Color.Lerp(startingColor,Color.white,1-ratio);

        Debug.Log(ratio);
    }
}
