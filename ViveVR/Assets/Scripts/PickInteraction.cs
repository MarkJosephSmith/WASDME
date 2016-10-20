using UnityEngine;
using System.Collections;

public class PickInteraction : MonoBehaviour {


    public Rigidbody RigidBody;
    private bool currentlyInteractive = false;
    private Controller_Action controller;
    private Transform interactionPoint;
    private float velocityFactor = 20000f;
    private Vector3 posDelta;
   
    // Use this for initialization
    void Start () {
        RigidBody = GetComponent<Rigidbody>();
        interactionPoint = gameObject.transform;
         velocityFactor /= RigidBody.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller && currentlyInteractive)
        {
            posDelta = controller.transform.position - interactionPoint.position;
            this.RigidBody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;
        }
        //this.RigidBody.rotation = Quaternion.identity;
        transform.localEulerAngles = new Vector3(0.0f, 90.0f, 90.0f);
        //if(controller)
         //this.interactionPoint.rotation =  controller.transform.rotation * Quaternion.Inverse(this.interactionPoint.rotation); 


    }
    public void BeginInteraction(Controller_Action current_Controller)
    {
        Debug.Log("InBeginInteraction for pick up");
        controller = current_Controller;
        interactionPoint.transform.SetParent(controller.transform);
        //interactionPoint.transform.SetParent(controller.transform);
        interactionPoint.position  = controller.transform.position;
        //interactionPoint.transform.parent = controller.transform;
        //interactionPoint.rotation = controller.transform.rotation;
        //interactionPoint.SetParent(transform, true);
        currentlyInteractive = true;
    }

    public void EndInteraction(Controller_Action current_Controller)
    {
        Debug.Log("InEndInteraction for pickup");
        if (controller == current_Controller)
        {
            interactionPoint.parent = null;
            controller = null;
            currentlyInteractive = false;

        }
    }

    public bool IsInteracting()
    {
        return currentlyInteractive;
    }

    public int whichController()
    {
        return 1;
    }
}



