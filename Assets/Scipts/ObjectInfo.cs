using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Instantiate(dropped1, new Vector3(spawn.x, spawn.y, spawn.z), Quaternion.identity);
            }
        }
        
        Destroy(gameObject);
    }
}
