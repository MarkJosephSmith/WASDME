using UnityEngine;
using System.Collections;
using System;

public class FireSphere : MonoBehaviour {
    private Rigidbody rigidbody;
    QuaryInteraction quaryItem;
   private bool startShootout=false;


    void Start()
    {
        gameObject.SetActive(false);
        rigidbody = gameObject.GetComponent<Rigidbody>();
       // AddSphereForce();
    }

    void Update() {
      //if(quaryItem.returnHits() >20)
      //  {
      //      gameObject.SetActive(true);
      //  }
      //if(startShootout)
        //{
            AddSphereForce();
        //}
       // AddSphereForce();
    }

    void AddSphereForce() {

        //float random1 = Random.RandomRange(-20, 20);
        //float random2 = Random.RandomRange(-20, 20);
        //float random3 = Random.RandomRange(-20, 20);
        //rigidbody.AddForceAtPosition(new Vector3(random1,random2,random3), gameObject.transform.position,ForceMode.Force);
       // rigidbody.AddForce(gameObject.transform.position-new Vector3(0.0f,2.0f,0.0f), ForceMode.Force);
        //rigidbody.transform.position = Vector3.MoveTowards( transform.position, new Vector3(0,0,0), Time.deltaTime * 3f);

    }
  
    public void setStartShoot()
    {
        startShootout = true;
    }

    public void TriggerShere()
    {
        gameObject.SetActive(true);
    }

    public static explicit operator FireSphere(GameObject v)
    {
        throw new NotImplementedException();
    }
}
