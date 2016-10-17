using UnityEngine;
using System.Collections;

public class snapScript : MonoBehaviour {

    //the offset of this trigger plate from the center of its parent cube.
    Vector3 offset;
    //Vector3 offset1;

    // Use this for initialization
    void Start () {

        //offset1 = Vector3.zero;
        offset = this.transform.position - this.transform.parent.gameObject.transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(offset.ToString());

        
	}

    void OnTriggerEnter(Collider other)
    {

        if ( (!(this.transform.parent.gameObject.GetComponent<liftable>().isLifted)) || (other.attachedRigidbody == null))// || !(other.attachedRigidbody.gameObject.GetComponent<liftable>().isLifted))//.gameObject.transform.parent.gameObject.GetComponent<liftable>().isLifted))
        {
            return;
        }
        else
        {
            //Debug.Log("entered else");
            //Debug.Log(other.gameObject);
            //Debug.LogWarning(other.attachedRigidbody.gameObject.tag);
            //GameObject testyObject = this.gameObject;
            Collider testyCollider = other;



            //GameObject testObject = new GameObject();


            if (testyCollider.attachedRigidbody.gameObject.tag == "stickable")
            {

                //GameObject testObject = other.transform.parent.gameObject;

                ohSnap(testyCollider);//.attachedRigidbody.gameObject); //the snapTrigger we have entered. 
            }
        } 
    }

    //snap to the box you collided with
    void ohSnap(Collider theCollision)
    {

        //Vector3 snapOffset = this.transform.localPosition;
        //Vector3 snapOffset = theCollision.
        Vector3 snapOffset = offset;


        GameObject o = theCollision.attachedRigidbody.gameObject;
        GameObject myParent = this.transform.parent.gameObject;
       //Vector3 testspace = o.transform.position - (offset * 2);
        myParent.transform.position = o.transform.position + (snapOffset * 2.0f);
        myParent.transform.rotation = o.transform.rotation;
        FixedJoint joint = myParent.AddComponent<FixedJoint>();
        joint.connectedBody = o.GetComponent<Rigidbody>();
        //joint.anchor = joint.anchor + snapOffset;
        //joint.connectedAnchor = joint.anchor;
        
        //joint.anchor = joint.anchor + offset;
        //joint.connectedAnchor = joint.connectedAnchor - offset;
        //joint.enableCollision = true;
        joint.breakForce = 100;//Mathf.Infinity;
        joint.breakTorque = 100;//Mathf.Infinity;

    }

}
