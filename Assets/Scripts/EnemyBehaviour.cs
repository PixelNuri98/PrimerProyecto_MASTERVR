using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        /*        if (other.name == "Player")
                {
                    Debug.Log("Player detected, attack");
                }*/
        print("hola");
        if (other.name == "Player")
        {
            Debug.Log("Player detected, attack");
        }
    }

    void OnTriggerExit(Collider other)
    {
        /*        if (other.name == "Player")
                {
                    Debug.Log("Player out of reach");
                }*/

        if (other.name == "Player")
        {
            Debug.Log("Player out of reach");
        }
    }

}


