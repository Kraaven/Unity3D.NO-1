using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public string Name;
    public float BreakTime;
    public bool breakable;

    public bool drops;
    public GameObject dropped1 = null;
    public int numdrop1;
    public GameObject dropped2 = null;
    public int numdrop2;

    public void breakobject(GameObject origin)
    {
        Vector3 spawn = origin.transform.position; 
        if (drops)
        {
            for (int i = 0; i < numdrop1; i++)
            {
                Debug.Log(spawn.z + 0.25f * i);
                Instantiate(dropped1, new Vector3(spawn.x, spawn.y + i, spawn.z), Quaternion.identity);
            }
        }
        
        Destroy(gameObject);
    }
}
