
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class Steering : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        [SerializeField] Transform SW;
        public float v;
        public float h;
        [SerializeField] bool SelfDriving;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");


            //float v = CrossPlatformInputManager.GetAxis("Vertical");

            if (!SelfDriving)
            {
                if (SW.transform.localEulerAngles.z <= 90)
                { h = SW.transform.localEulerAngles.z / -90; }
                else
                {
                    if (SW.transform.localEulerAngles.z >= 270)
                        h = (SW.transform.localEulerAngles.z - 360) / -90;
                }
                if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
                {
                    v = 1;
                }
                else
                {
                    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        v = -1;
                    }
                    else
                    {
                        v = 0;
                    }
                }
            }


#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
