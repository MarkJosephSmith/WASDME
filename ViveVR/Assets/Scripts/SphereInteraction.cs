using UnityEngine;
using System.Collections;

public class SphereInteraction : MonoBehaviour {

    public Rigidbody RigidBody;
    private bool currentlyInteractive;
    private Controller_Action controller;
    private Transform currentPosition;
    private Vector3 tempPosition;
    private bool objectiveReached;
    
    // Use this for initialization
    void Start () {
        RigidBody = GetComponent<Rigidbody>();
        currentlyInteractive = false;
        objectiveReached = false;
        currentPosition = new GameObject().transform;
        tempPosition = Vector3.zero;
     }
	
	// Update is called once per frame
	void Update () {
        if (controller)
        {
            tempPosition = controller.transform.position - currentPosition.position;
        }


	if(tempPosition.sqrMagnitude > 0.4 && objectiveReached!=true && controller)
       {
            Debug.Log("OBjective reached in sphere");
            this.RigidBody.velocity = Vector3.one* 200f * Time.fixedDeltaTime;
            this.RigidBody.useGravity = true;
            objectiveReached = true;
            EndInteraction(controller);
        }
	}
    public void BeginInteraction(Controller_Action current_Controller)
    {
        Debug.Log("InBeginInteraction in Sphere");
        controller = current_Controller;
        currentPosition.position = controller.transform.position;
        currentlyInteractive = true;
    }

    public void EndInteraction(Controller_Action current_Controller)
    {
        Debug.Log("InEndInteraction in cube");
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

}
