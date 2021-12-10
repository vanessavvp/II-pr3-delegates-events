using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public delegate void CollisionWithObject();
    public static event CollisionWithObject OnCollisionWithObject;
    
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision) { 
        if (collision.gameObject.tag == "Player") {
            if (OnCollisionWithObject != null) {
                OnCollisionWithObject();
            }
        }
    }
}
