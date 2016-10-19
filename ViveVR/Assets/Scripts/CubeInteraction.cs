using UnityEngine;
using System.Collections;

public class CubeInteraction : MonoBehaviour {

    public Rigidbody RigidBody;
    private bool currentlyInteractive = false;
    private Controller_Action controller;

    private Vector3 posDelta;
    private Quaternion rotDelta;
    private float angle;
    private Vector3 axis;
    private float rotationFactor = 400f;
    private float velocityFactor = 20000f;

    private Transform interactionPoint;

	// Use this for initialization
	void Start () {
        RigidBody = GetComponent<Rigidbody>();
        interactionPoint = new GameObject().transform;
        velocityFactor /= RigidBody.mass;
        rotationFactor /= RigidBody.mass;
	}

    // Update is called once per frame
    void Update() {
        if (controller && currentlyInteractive){
            posDelta = controller.transform.position - interactionPoint.position;
            this.RigidBody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;

            rotDelta = controller.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
            rotDelta.ToAngleAxis(out angle, out axis);

            if(angle > 180)         // if bigger than 160 need to rotateit in opposite way
            {
                angle -= 360;
            }
            this.RigidBody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
        }
    }
   public void BeginInteraction(Controller_Action current_Controller)
    {
        Debug.Log("InBeginInteraction in Cube");
        controller = current_Controller;
        interactionPoint.position = controller.transform.position;
        interactionPoint.rotation = controller.transform.rotation;
        interactionPoint.SetParent(transform, true);
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
