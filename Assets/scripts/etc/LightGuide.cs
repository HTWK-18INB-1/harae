using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGuide : MonoBehaviour
{
    bool[] isMove = new bool[3] {false,false,false};
    
    private GameObject player;

    public GameObject enemyBoss;
    private GameObject bossParticle;

    public GameObject finalBook;
    public GameObject firstBook;

    private Light light;
    //private Halo halo;
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        light = GetComponent<Light>();
        startingColor = light.color;
        bossParticle = enemyBoss.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        moveToDestination(player);
        lvlProcedure();
    }


    void riseAndShine(GameObject book,int childIndex){
            book.transform.GetChild(childIndex).gameObject.GetComponent<ParticleSystem>().Play();
            if(book.transform.position.y < 3){
                Vector3 temp = book.transform.position;
                book.transform.position += new Vector3(0,1*Time.deltaTime,0);
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
            if(helper>5){
                riseAndShine(firstBook,5);
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
            if(helper>10){
                riseAndShine(finalBook,3);
            }
        }

        //TODO : wenn zweites Item gefunden dann -> 

            enemyAppear();
        

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

        float ratio = 1-(newDistance/startDistance);
        light.color = Color.Lerp(startingColor,Color.red,ratio);
    }

    void enemyAppear(){
        if(enemyBoss.transform.position.y<0){
            bossParticle.GetComponent<ParticleSystem>().Play();
            Vector3 temp = bossParticle.transform.position;
            enemyBoss.transform.position += new Vector3(0,3*Time.deltaTime,0);
                bossParticle.transform.position = temp;
        }

        
        
    }
}
