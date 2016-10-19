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
        interactionPoint = new GameObject().transform;
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
    }
    public void BeginInteraction(Controller_Action current_Controller)
    {
        Debug.Log("InBeginInteraction for pick up");
        controller = current_Controller;
        interactionPoint.position = controller.transform.position;
        interactionPoint.rotation = Quaternion.identity;
        interactionPoint.SetParent(transform, true);
        currentlyInteractive = true;
    }

    public void EndInteraction(Controller_Action current_Controller)
    {
        Debug.Log("InEndInteraction for pickup");
        if (controller == current_Controller)
        {
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



