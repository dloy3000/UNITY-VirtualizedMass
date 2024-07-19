using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassVirtualizer : MonoBehaviour
{
    private VirtualMass[] componentMass;
    private Rigidbody objectRB;
    private Vector3 massCenter;

    //Start is called before the first frame update
    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
        componentMass = this.GetComponentsInChildren<VirtualMass>();

        VirtualizeMass();
    }
    /**
    *Calculate the center of mass using the virualized masses,
    *and set the center of mass for this rigidbody accordingly.
    */
    void VirtualizeMass()
    {
        double x = 0d, y = 0d, z = 0d;
        int count = 0;

        for (int i = 0; i < componentMass.Length; i++)
        {
            Debug.Log($"{i}: {componentMass[i].Centroid}");
            x += componentMass[i].Centroid.x;
            y += componentMass[i].Centroid.y;
            z += componentMass[i].Centroid.z;
            count++;
        }

        massCenter = new Vector3((float)x, (float)y, (float)z);
        Debug.Log($"Mass Center: [{x}, {y}, {z}]");

        objectRB.automaticCenterOfMass = false;
        objectRB.centerOfMass = massCenter;
    }
}