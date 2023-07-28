using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public GameObject touch;
    public bool see = false;
    public GameObject camera;
    public bool isbreaking = false;

    public float breaktime = 0;

    public float breaktick = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out Hit, 3.5f))
        {
            touch = Hit.transform.gameObject;
            Debug.Log(touch.GetComponent<ObjectInfo>().Name);
            
        }
        
        
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Button Down");
            


        }
        
    }
}
