using System.Collections;
using System.Collections.Generic;
using Oculus;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 position;
    public float Speed = 0;
    public float MaxSpeed = 10;
    public float Acceleration = 10;
    public float Deceleration = 10;
    public float rotateSpeed = 2;


    void Update()
    {
        if ((OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) && (Speed < MaxSpeed))
        {
            Speed = Speed - (Acceleration * Time.deltaTime);
        }
        else if ((OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)) && (Speed > -MaxSpeed))
        {
            Speed = Speed + (Acceleration * Time.deltaTime);
        }
        else
        {
            if (Speed > Deceleration * Time.deltaTime)
            {
                Speed = Speed - Deceleration * Time.deltaTime;
            }
            else if (Speed < -Deceleration * Time.deltaTime)
            {
                Speed = Speed + Deceleration * Time.deltaTime;
            }
            else
            {
                Speed = 0;
            }
        }


        position.z = transform.position.z + Speed * Time.deltaTime;
        transform.position = position;

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        }
    }
}
