using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{   
    

    void OnCollisionEnter(Collision coll)
    {
    // Hier kann man den Code einsetzen, der Bei einer Berührung
    // ausgeführt werden soll.

        Debug.Log("COLLISION START");
        if(gameObject.CompareTag("environmentObject")){
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("Hit envirnemt Object!");
        }

    }

    void OnCollisionStay(Collision coll)
    {
    // Dieser Code wird so lange sich die beiden Objekte berühren
    // mit jeden Frame ein mal ausgeführt.
        
        Debug.Log("COLLISION STAY");
    }

    void OnCollisionExit(Collision coll)
    {
    // Wenn die beiden Objekte die Berührung verlassen
    // wird diese Methode ausgeführt.

        Debug.Log("COLLISION EXIT");
    }
}
