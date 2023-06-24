using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    

    public Rigidbody2D theRB;
   


    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        
    }

    public void wakeRigidBody2D()
    {
        theRB.WakeUp();
    }

    


}
