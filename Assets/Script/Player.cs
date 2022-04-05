using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public int points = 0;
    public OVRGrabber grabberLeft;
    public OVRGrabber grabberRight;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GainAPoint()
    {
        points++;
    }

    public IEnumerator Vibrate()
    {
        OVRInput.Controller controller;

        if (grabberRight.grabbedObject != null) 
        {
            controller = OVRInput.Controller.RTouch;
        }
        else
        {
            controller = OVRInput.Controller.LTouch;
        }

        OVRInput.SetControllerVibration(1, 1, controller);
        yield return new WaitForSeconds(0.2f);
        OVRInput.SetControllerVibration(0, 0, controller);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
