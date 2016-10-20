using UnityEngine;
using System.Collections;

public class QuaryInteraction : MonoBehaviour {

    private static int hits;
    private bool isInteracting;
    public GameObject Cube;
    public GameObject I;
    public GameObject L;
    public GameObject S;
    public GameObject T;
    public GameObject dummyCube;
    PickInteraction pickItem;
    // Use this for initialization
    void Start () {
        isInteracting = false;
        hits = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(isInteracting == true)
        {
            float randomXPosition = Random.Range(-1.0f, 1.5f);
            float randomYPosition = 1.0f;// Random.Range(0, 2);
            float randomZPosition = Random.Range(-1.5f, 1.5f);
            
            int randomPickUpNumber = Random.Range(0, 4);
            GameObject tempCube;

            if (hits % 2 == 0)
            {
                tempCube = Instantiate(dummyCube, new Vector3(randomXPosition, randomYPosition, randomZPosition), Quaternion.identity) as GameObject;
                //tempCube.AddComponent<Rigidbody>();
                tempCube.GetComponent<Rigidbody>().useGravity = true;
                tempCube.GetComponent<Rigidbody>().mass = Random.Range(10, 20);
                Debug.Log("in quaryInteraction New object is spawned");
                

                /*
                switch (0)
                {

                    case 0:
                        tempCube = Instantiate(Cube, new Vector3(randomXPosition, randomYPosition, randomZPosition), Quaternion.identity) as GameObject;
                       // tempCube.AddComponent<Rigidbody>();
                        tempCube.GetComponent<Rigidbody>().useGravity = true;
                        tempCube.GetComponent<Rigidbody>().mass = Random.Range(0, 50);
                        Debug.Log("New object is spawned");
                        break;
                    case 1:
                        tempCube = Instantiate(I, new Vector3(randomXPosition, randomYPosition, randomZPosition), Quaternion.identity) as GameObject;

                        //tempCube.AddComponent<Rigidbody>();
                        tempCube.GetComponent<Rigidbody>().useGravity = true;
                        tempCube.GetComponent<Rigidbody>().mass = Random.Range(0, 50);
                        Debug.Log("New object is spawned");

                        break;
                    case 2:
                        tempCube = Instantiate(S, new Vector3(randomXPosition, randomYPosition, randomZPosition), Quaternion.identity) as GameObject;
                        //tempCube.AddComponent<Rigidbody>();
                        tempCube.GetComponent<Rigidbody>().useGravity = true;
                        tempCube.GetComponent<Rigidbody>().mass = Random.Range(0, 50);
                        Debug.Log("New object is spawned");
                        break;
                    case 3:
                        tempCube = Instantiate(T, new Vector3(randomXPosition, randomYPosition, randomZPosition), Quaternion.identity) as GameObject;

                        //tempCube.AddComponent<Rigidbody>();
                        tempCube.GetComponent<Rigidbody>().useGravity = true;
                        tempCube.GetComponent<Rigidbody>().mass = Random.Range(0, 50);
                        Debug.Log("New object is spawned");
                        break;
                    case 4:
                        tempCube = Instantiate(L, new Vector3(randomXPosition, randomYPosition, randomZPosition), Quaternion.identity) as GameObject;

                       // tempCube.AddComponent<Rigidbody>();
                        tempCube.GetComponent<Rigidbody>().useGravity = true;
                        tempCube.GetComponent<Rigidbody>().mass = Random.Range(0, 50);
                        Debug.Log("New object is spawned");
                        break;

                    default:
                        break;

                } */
            }
            Debug.Log("in quaryInteraction New object is spawned");
            isInteracting = false;
        }
	}

    private void OnTriggerEnter(Collider collider)
    {
        pickItem = collider.GetComponent<PickInteraction>();
        
         if (pickItem!=null)
        {
            hits++;
            isInteracting = true;
            Debug.Log("In quaryInteraction Trigger occured on pickup");
        }

    }
    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("In quaryInteraction Trigger released on pickup");

    }
    public int returnHits()
    {
        return hits;
    }
}
