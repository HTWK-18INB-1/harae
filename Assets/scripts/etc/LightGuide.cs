using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LightGuide : MonoBehaviour
{
    private InputDevice inputController; 

    bool[] isMove = new bool[2] {false,false};
    
    private GameObject player;

    public GameObject enemyBoss;
    private GameObject bossParticle;

    public GameObject finalBook;
    public GameObject firstBook;

    public GameObject rightHandPlayer;
    public GameObject leftHandPlayer;

    public GameObject rightHandParticle;
    public GameObject leftHandParticle;

    private Light light;
    private Color startingColor;

    public float movementSpeed;

    Vector3 targetPosition;
    Vector3 currentPosition;
    Vector3 directionOfTravel;

    Vector3[] startPosition = new Vector3[2];
    private bool[] firstStart = new bool[2] {true,true};
    private float newDistance;
    private float startDistance;


    public float helper = 0f;

    public bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        light = GetComponent<Light>();
        startingColor = light.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        moveToDestination(player);
        lvlProcedure();
    }

    void addParticle(GameObject hand, GameObject particle){
        particle.transform.SetParent(hand.transform);
    }

    void riseAndShine(GameObject book,int childIndex,GameObject hand, GameObject particle){
            book.transform.GetChild(childIndex).gameObject.GetComponent<ParticleSystem>().Play();
            if(book.transform.position.y < 3){
                Vector3 temp = book.transform.position;
                book.transform.position += new Vector3(0,1*Time.deltaTime,0);
            }

            else {
                Destroy(book);
                addParticle(hand,particle);
            }

        }

    void lvlProcedure(){
        isMove[0] = true;

        if(isMove[0]){
            if(firstStart[0]){
                startPosition[0] = this.transform.position;
            }
            firstStart[0] = false;
            changeColor(firstBook,startPosition[0]);
            if(inputController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue){
                riseAndShine(firstBook,5,rightHandPlayer,rightHandParticle);
                isMove[1] = true;
            }
            
        }

        //TODO : wenn erstes Item gefunden dann -> 
        if(isMove[1]){
            isMove[0]=false;
            if(firstStart[1]){
                startPosition[1] = this.transform.position;
            }
            firstStart[1] = false;
            changeColor(finalBook,startPosition[1]);
            if(inputController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue){      
                riseAndShine(finalBook,3,leftHandPlayer,leftHandParticle);  
            }
        }

        //TODO : wenn zweites Item gefunden dann -> 
            //isFinished = true;
            
        

    }

    void moveToDestination(GameObject destination){
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
         }
    }

    void changeColor(GameObject destination,Vector3 startPositionf) {
        targetPosition = destination.transform.position; // Get position of object B
        currentPosition = this.transform.position; // Get position of object A
        newDistance = Vector3.Distance(currentPosition,targetPosition);
        startDistance = Vector3.Distance(startPositionf,targetPosition);

        float ratio = 1-(newDistance/startDistance);
        light.color = Color.Lerp(startingColor,Color.red,ratio);
    }

        
        
    
}
