using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectB : MonoBehaviour {
    public delegate void delegateCollisionB();
    public static event delegateCollisionB eventCollisionB;
    public Text DisplayText;
    private int force;

    void Start() 
    {
        force = 0;
        ObjectA.eventCollisionA += increaseForce;
        ObjectA.eventCloserDistanceA += changeColor;
        ObjectA.eventInitialPosA += changeToInitialColor;
    }

    void  OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Player" && eventCollisionB != null) 
        {
            eventCollisionB();
        }
    }

    void  OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            DisplayText.text = "The zombie is hunting...";
        }
    }

    void increaseForce() 
    {
        force++;
        DisplayText.text = "Object B: My force is incremented to... " + force + " I'm strong!";
    }

    void changeColor() 
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void changeToInitialColor() 
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}