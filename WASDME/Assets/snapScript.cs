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


        myParent.transform.position = o.transform.position + (snapOffset * 2.00f);
        myParent.transform.rotation = o.transform.rotation;
        //FixedJoint joint = myParent.AddComponent<FixedJoint>();
        //joint.connectedBody = o.GetComponent<Rigidbody>();

        o.GetComponent<Rigidbody>().useGravity = false;

        
        myParent.transform.position = o.transform.position + (snapOffset * 2.05f);
        myParent.transform.rotation = o.transform.rotation;
        ConfigurableJoint joint = myParent.AddComponent<ConfigurableJoint>();
        joint.connectedBody = o.GetComponent<Rigidbody>();
        joint.configuredInWorldSpace = false;
        //joint.anchor = new Vector3(0, 0, 0);
        //joint.connectedAnchor = new Vector3(0, 0, 0);
        joint.enableCollision = false;
        joint.enablePreprocessing = true;
        joint.xMotion = ConfigurableJointMotion.Locked;
        joint.yMotion = ConfigurableJointMotion.Locked;
        joint.zMotion = ConfigurableJointMotion.Locked;
        joint.angularXMotion = ConfigurableJointMotion.Locked;
        joint.angularYMotion = ConfigurableJointMotion.Locked;
        joint.angularZMotion = ConfigurableJointMotion.Locked;
        joint.linearLimit.limit.Equals(0.0f);
        joint.linearLimit.bounciness.Equals(0.0f);
        joint.linearLimit.contactDistance.Equals(0.0f);
        joint.linearLimitSpring.spring.Equals(0.0f);
        joint.linearLimitSpring.damper.Equals(0.0f);
        joint.highAngularXLimit.limit.Equals(0.0f);
        joint.lowAngularXLimit.limit.Equals(0.0f);
        joint.highAngularXLimit.bounciness.Equals(0.0f);
        joint.lowAngularXLimit.bounciness.Equals(0.0f);
        joint.highAngularXLimit.contactDistance.Equals(0.0f);
        joint.lowAngularXLimit.contactDistance.Equals(0.0f);


        joint.angularYLimit.bounciness.Equals(0.0f);
        joint.angularYLimit.limit.Equals(0.0f);
        joint.angularYLimit.contactDistance.Equals(0.0f);

        joint.angularZLimit.limit.Equals(0.0f);
        joint.angularZLimit.bounciness.Equals(0.0f);
        joint.angularZLimit.contactDistance.Equals(0.0f);

        joint.angularYZLimitSpring.spring.Equals(0.0f);
        joint.angularYZLimitSpring.damper.Equals(0.0f);

        joint.targetVelocity.Equals(Vector3.zero);
        joint.projectionAngle.Equals(0.1f);
        joint.projectionDistance.Equals(0.1f);
        //joint.projectionMode.Equals()

        Rigidbody otherBody = o.GetComponent<Rigidbody>();


        otherBody.useGravity = false;

        otherBody.maxAngularVelocity.Equals(10);
        myParent.GetComponent<Rigidbody>().maxAngularVelocity.Equals(10);




        //joint.anchor = joint.anchor + snapOffset;
        //joint.connectedAnchor = joint.anchor;

        //joint.anchor = joint.anchor + offset;
        //joint.connectedAnchor = joint.connectedAnchor - offset;
        //joint.enableCollision = true;
        joint.breakForce = Mathf.Infinity;
        joint.breakTorque = Mathf.Infinity;
        



    }

}
