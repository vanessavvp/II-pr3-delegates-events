using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectA : MonoBehaviour {
    public delegate void delegateCollisionA();
    public static event delegateCollisionA eventCollisionA;
    public static event delegateCollisionA eventCloserDistanceA;
    public static event delegateCollisionA eventInitialPosA;
    float DistanceWithPlayer;
    GameObject Player;
    public Text DisplayText;

    void Start() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ObjectB.eventCollisionB += changeText;
    }

    void Update() 
    {
        DistanceWithPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (DistanceWithPlayer <= 3.0f) 
        {
            eventCloserDistanceA();
        } else {
            eventInitialPosA();
        }
    }

    void  OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && eventCollisionA != null) 
        {
            eventCollisionA();
        }
    }

    void  OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            DisplayText.text = "The zombie is hunting...";
        }
    }

    void changeText() 
    {
        DisplayText.text = "Object A: OH NO! The zombie attacked the Object B";
    }
}