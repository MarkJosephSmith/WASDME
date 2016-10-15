using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

    GameObject pickedUp;
    float pickedUpSize;
	
    GameObject GetMouseHoverObject(float range)
    {
        Vector3 possition = gameObject.transform.position;
        RaycastHit rayHit;
        Vector3 target = possition + Camera.main.transform.forward * range;
        if (Physics.Linecast(possition, target, out rayHit))
        {
            return rayHit.collider.gameObject;
        }
        return null;
    }


    void pickUp(GameObject tryPickup)
    {
        if (tryPickup == null || (tryPickup.tag != "stickable"))
        {
            return;
        }

        pickedUp = tryPickup;
        pickedUpSize = pickedUp.GetComponent<Renderer>().bounds.size.magnitude;


    }

    void dropObject()
    {
        if (pickedUp == null)
        {
            return;
        }

        if (pickedUp.GetComponent<Rigidbody>() != null)
        {
            pickedUp.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }


        pickedUp = null;
        pickedUpSize = 0;
    }

	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pickedUp == null)
            {
                pickUp(GetMouseHoverObject(5));
            }
            else
            {
                dropObject();
            }



        }

        if (pickedUp != null)
        {
            Vector3 newPossition = gameObject.transform.position + Camera.main.transform.forward * pickedUpSize;
            pickedUp.transform.position = newPossition;
        }

    }
}
