using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{


    public NavMeshAgent AIObject;

    public GameObject player;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 positionVector3 = player.transform.position;
        AIObject.SetDestination(positionVector3);
    }
}
