using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller_Action : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
  

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    // public bool gripButtonPressed = false;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
  //  public bool triggerButtonPressed = false;

   
    HashSet<CubeInteraction> objectsHoveringOver = new HashSet<CubeInteraction>();
    private CubeInteraction closetObject;
    private CubeInteraction interactingObject;

   /* HashSet<HandleInteraction> handlesHoveringOver = new HashSet<HandleInteraction>();
    private HandleInteraction closetHandle;
    private HandleInteraction interactingHandle;

    */

    private PickInteraction pickObject;
    private PickInteraction pickTemp;
    HashSet<PickInteraction> objectPickupObject = new HashSet<PickInteraction>();
    private bool isInteracting;
    private bool isCube;



    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        isInteracting = false;
        isCube = false;


    }
    void Update()
    {

        if (controller == null)
        {
            Debug.Log("Controller is not intialized");
            return;
        }

            gripButtonDown = controller.GetPressDown(gripButton);
            gripButtonUp = controller.GetPressUp(gripButton);
        //    gripButtonPressed = controller.GetPress(gripButton);

            triggerButtonDown = controller.GetPressDown(triggerButton);
            triggerButtonUp = controller.GetPressUp(triggerButton);
        //    triggerButtonPressed = controller.GetPress(triggerButton);



        if (triggerButtonDown && isInteracting)
        {
            float minDistance = float.MaxValue;
            float distance;


            if (isCube)
            {

                foreach (CubeInteraction item in objectsHoveringOver)
                {
                    distance = (item.transform.position - transform.position).sqrMagnitude;
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closetObject = item;
                    }
                }

                interactingObject = closetObject;
                if (interactingObject)
                {
                    if (interactingObject.IsInteracting())
                    {
                        interactingObject.EndInteraction(this);
                    }

                    interactingObject.BeginInteraction(this);
                }
            }
            /*
            //if it is handle.
            foreach (HandleInteraction item in handlesHoveringOver)
            {
                distance = (item.transform.position - transform.position).sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closetHandle = item;
                }
            }

            interactingHandle = closetHandle;
            if (interactingHandle)
            {
                if (interactingHandle.IsInteracting())
                {
                    interactingHandle.EndInteraction(this);
                }

                interactingHandle.BeginInteraction(this);
            }
            */
            else
            {
                foreach (PickInteraction item in objectPickupObject)
                {
                    distance = (item.transform.position - transform.position).sqrMagnitude;
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        pickTemp = item;
                    }
                }

                pickObject = pickTemp;
                if (pickObject)
                {
                    if (pickObject.IsInteracting())
                    {
                        pickObject.EndInteraction(this);
                    }

                    pickObject.BeginInteraction(this);
                }
            }
        }

         if (triggerButtonUp && interactingObject !=null)
         {
             interactingObject.EndInteraction(this);
             isInteracting = false;
            interactingObject = null;
             Debug.Log("in controllerAction TriggerButton released for cube");
         }
         if (triggerButtonUp && pickObject!=null)
        {
            pickObject.EndInteraction(this);
            isInteracting = false;
            pickObject = null;
            Debug.Log("in controllerAction TriggerButton released for pick up");
        }
        /*  else if (gripButtonUp && interactingHandle != null)
        {
            interactingHandle.EndInteraction(this);
            isInteracting = false;
            Debug.Log("Grip Button released for handle");
        }*/

   }

   private void OnTriggerEnter(Collider collider)
   {
       CubeInteraction collidedItem = collider.GetComponent<CubeInteraction>();
      // HandleInteraction handleItem = collider.GetComponent<HandleInteraction>();
       PickInteraction pickItem = collider.GetComponent<PickInteraction>();
        SphereInteraction sphereObject = collider.GetComponent<SphereInteraction>();
      if (collidedItem != null)
       {
            isCube = true;
           objectsHoveringOver.Add(collidedItem);
           isInteracting = true;
           Debug.Log("In controllerAction OntriggerenterTrigger entered on collider pickup");
       }
      /* else if(handleItem!=null)
       {
           isInteracting = true;
           handlesHoveringOver.Add(handleItem);
           Debug.Log("Trigger occured on collider for handle");
       }*/
        if (pickItem!=null)
        {
            isCube = false;
            isInteracting = true;
            objectPickupObject.Add(pickItem);
            Debug.Log("In controllerAction OntriggerenterTrigger entered on collider pickup");
        }

        if(sphereObject!=null)
        {
            sphereObject.BeginInteraction(this);
            Debug.Log("In controllerAction OntriggerenterTrigger entered on collider sphere");
        }


    }
    private void OnTriggerExit(Collider collider)
    {
        PickInteraction pickItem = collider.GetComponent<PickInteraction>();
        CubeInteraction collidedItem = collider.GetComponent<CubeInteraction>();
        if (collidedItem != null)
        {
            objectsHoveringOver.Remove(collidedItem);
            Debug.Log("In controllerAction OntriggerExit Trigger exited on collider cube");
        }
        if (pickItem != null)
        {
            objectPickupObject.Remove(pickItem);
            Debug.Log("In controllerAction OntriggerExit Trigger exited on collider pickup");
        }
        
    }


}