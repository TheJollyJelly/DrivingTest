using System.Collections;
using System.Collections.Generic;
using Oculus;
using UnityEngine;

public class Movement : Player
{
    public float Speed = 0;
    public float MaxSpeed = 10;
    public float Acceleration = 10;
    public float Deceleration = 10;
    public float rotateSpeed = 2;

    public GameObject pass;
    public GameObject fail;


    void Start()
    {
        pass.SetActive(false);
        fail.SetActive(false);
    }

    void Update()
    {
        if ((OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)))
        {
            transform.position -= transform.forward * Time.deltaTime * MaxSpeed;
        }
        else if ((OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)))
        {
            transform.position += transform.forward * Time.deltaTime * MaxSpeed;
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

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            transform.Rotate(0, Time.deltaTime * -rotateSpeed, 0);
        }

        //if (Points >= 75)
        //{
        //    pass.SetActive(true);
        //}
        //if (Points <= 74)
        //{
        //    fail.SetActive(true);
        //}
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cone")
        {
            Points --;
        }

    }

}
