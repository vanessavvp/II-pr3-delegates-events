using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The rescuer - Is meant to look at the player if this one 
 * is closer to the A object */
public class Rescuer : MonoBehaviour
{
    Transform target;
    void Start()
    {
        ObjectA.eventCloserDistanceA += LookAtTarget;
        ObjectA.eventInitialPosA += ChangeToInitialPos;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    public void LookAtTarget()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.white, 0.1f, true);
        transform.LookAt(target);
    }

    public void ChangeToInitialPos()
    {
        transform.rotation = Quaternion.identity;
    }
}
