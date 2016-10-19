using UnityEngine;
using System.Collections;

public class PickupObject2 : MonoBehaviour
{

    GameObject mainCamera;
    bool isCarrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;

	// Use this for initialization
	void Start ()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isCarrying)
        {
            carry(carriedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }

	}

    void carry(GameObject o)
    {
        //o.transform.position = Vector3.Lerp( o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        //o.transform.rotation = Quaternion.identity; //keeps it from spinning in air by resetting the rotation.

        //works but trying other things
        o.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth));
        //o.GetComponent<Rigidbody>().MoveRotation(Quaternion.identity);



    }

    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray shootRay = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit rayHit;

            if (Physics.Raycast(shootRay, out rayHit))
            {
                liftable p = rayHit.collider.GetComponent<liftable>();
                if (p != null)
                {
                    //works for 1 cube, trying it with 4 and a parent
                    isCarrying = true;
                    carriedObject = p.gameObject;
                    //p.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    p.isLifted = true;  /////////////////////////will need to set this for all jointed objects
                    

                    isCarrying = true;
                    carriedObject = p.gameObject;

                    Component[] connected = carriedObject.GetComponents<ConfigurableJoint>();


                    foreach (ConfigurableJoint joint in connected)
                    {

                        joint.connectedBody.GetComponent<Rigidbody>().useGravity = false;


                    }



                    /*
                    Component[] childrens = p.gameObject.transform.parent.GetComponentsInChildren<Rigidbody>();

                    foreach(Rigidbody child in childrens)
                    {
                        //child.gameObject.GetComponent<PickupObject2>().isCarrying = true;
                        child.useGravity = false;


                    }
                    */


                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        isCarrying = false;
        //carriedObject.GetComponent<Rigidbody>().isKinematic = false;





        carriedObject.GetComponent<Rigidbody>().useGravity = true;
        liftable p = carriedObject.GetComponent<Collider>().GetComponent<liftable>();

        Component[] connected = carriedObject.GetComponents<ConfigurableJoint>();

        
        foreach (ConfigurableJoint joint in connected)
        {
            
            joint.connectedBody.GetComponent<Rigidbody>().useGravity = true;

           
        }


        p.isLifted = false;  ///////////////////////////////////will need to set this for all jointed objects
        carriedObject = null;

    }
}
