using UnityEngine;
using System.Collections;

public class PlaneInteraction : MonoBehaviour {

    public GameObject cloudPrefabs;
    public float smooth;
         public float tiltAngle;
    // Use this for initialization
    void Start () { 
    smooth = 2.0F;
    tiltAngle =130.0F;
}
	
	// Update is called once per frame
	void Update () {
        
        cloudPrefabs.transform.Rotate(Vector3.up * (Time.deltaTime *2f) ,Space.World);
      
	}
}
