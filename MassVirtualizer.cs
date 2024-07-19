using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassVirtualizer : MonoBehaviour
{
    private VirtualMass[] componentMass;
    private Rigidbody objectRB;
    private Vector3 massCenter;
    private float massTotal;

    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
        componentMass = this.GetComponentsInChildren<VirtualMass>();
        massTotal = objectRB.mass;

        VirtualizeMass();
    }
    /**
    *Calculate the center of mass using the virualized masses,
    *and set the center of mass for this rigidbody accordingly.
    */
    void VirtualizeMass()
    {
        double x = 0d, y = 0d, z = 0d;
        float m = 0;
        int count = 0;

        for (int i = 0; i < componentMass.Length; i++)
        {
            m += componentMass[i].mass;

            x += componentMass[i].Centroid.x;
            y += componentMass[i].Centroid.y;
            z += componentMass[i].Centroid.z;

            count++;
        }

        massTotal = m;
        massCenter = new Vector3((float)x, (float)y, (float)z);

        objectRB.mass = massTotal;
        objectRB.automaticCenterOfMass = false;
        objectRB.centerOfMass = massCenter;

        //Debug.Log($"Mass Center: [{x}, {y}, {z}]");
    }
}