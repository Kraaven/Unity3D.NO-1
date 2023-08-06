using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectInfo : MonoBehaviour
{
    [Header("Name")]
    public string Name;
    
    [Header("Break Settings")]
    public float BreakTime;
    public bool breakable;

    [Header("Drop Settings")] 
    public bool drops;
    public GameObject dropped1 = null;
    public int numdrop1;
    public GameObject dropped2 = null;
    public int numdrop2;
    public bool isdrop;
    
    [Header("Pickup Settings")]
    public bool BePickedUp;

    public float rotx;
    public float roty;
    public float rotz;

    public void breakobject(GameObject origin)
    {
        Vector3 spawn = origin.transform.position; 
        if (drops)
        {
            for (int i = 0; i < numdrop1; i++)
            {
                Debug.Log(spawn.z + 0.25f * i);
                Quaternion spawnrot = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                Instantiate(dropped1, new Vector3(spawn.x + Random.Range(-1f,1f) , spawn.y+ (dropped1.GetComponent<MeshRenderer>().bounds.size.y*i*1.3f), spawn.z + Random.Range(-1f,1f)), spawnrot );

            }
        }
        
        Destroy(gameObject);
    }

    public void Start()
    {
        if (isdrop)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            Invoke("coleneable", 0.1f);
        }
    }

    public void coleneable()
    {
        Debug.Log(name + " collider enabled");
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
