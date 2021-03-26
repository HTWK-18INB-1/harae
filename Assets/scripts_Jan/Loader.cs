using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public int Level;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(Level);
    }
}
