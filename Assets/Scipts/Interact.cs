using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Interact : MonoBehaviour
{
    
    public GameObject touch;
    public bool see = false;
    public GameObject camera;
    public bool isbreaking = false;

    public float breaktime = 0;
    public GameObject prev;

    public float breaktick = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        prev = touch;
        RaycastHit Hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out Hit, 3.5f))
        {    
            touch = Hit.transform.gameObject;
            Debug.Log(touch.GetComponent<ObjectInfo>().Name);
            
        }
        else
        {
            touch = null;
        }


        if (Input.GetMouseButton(0) && touch != null)
        {

            if (prev != touch)
            {
                reset();
                isbreaking = false;
                breaktick = 0;
                breaktime = 0;
            }

            if (touch.GetComponent<ObjectInfo>().breakable)
            {
                isbreaking = true;
            }

            breaktime = touch.GetComponent<ObjectInfo>().BreakTime;
            
            // while (isbreaking)
            // {
            //     if (!touch.GetComponent<ObjectInfo>().breakable)
            //     {
            //         break;
            //     }
            //     breaktick += Time.deltaTime;
            //     // if (breaktick >= breaktime)
            //     // {
            //     //     Destroy(touch);
            //     //     isbreaking = false;
            //     //     touch = null;
            //     // }
            // }
            breaktick += Time.deltaTime;
            if (breaktick > breaktime && isbreaking)
            {
                touch.GetComponent<ObjectInfo>().breakobject(gameObject);
                reset();
            }



        }
        if (Input.GetMouseButtonUp(0))
        {
            reset();
        }

        // if (Input.GetMouseButtonUp(0))
        // {
        //     isbreaking = false;
        //     breaktick = 0;
        //     breaktime = 0;
        // }

    }

    private void reset()
    {
        isbreaking = false;
        breaktick = 0;
        breaktime = 0;
        touch = null;
    }
}
