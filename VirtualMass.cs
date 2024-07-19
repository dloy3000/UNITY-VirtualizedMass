using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class VirtualMass : MonoBehaviour
{
    public float mass;

    public float solidness;

    private Vector3[] meshVertex;

    [SerializeField] private MassScalar centroid;

    public MassScalar Centroid { get { return centroid; } }

    void Awake()
    {
        meshVertex = this.GetComponent<MeshFilter>().sharedMesh.vertices; //Vertexes of the mesh.
        centroid = ReturnCentroid(); //Get Center of volume.

        //Debug.Log($"{this.gameObject.name}: {centroid}");
    }

    //Calculates the centroid value of the mesh.
    private MassScalar ReturnCentroid()
    {
        double x = 0d, y = 0d, z = 0d;
        int count = 0;

        for (int i = 0; i < meshVertex.Length; i++)
        {
            //EVENTUALLY: Add functionality to skip duplicate vertices created by Unity, using a dict or hashmap.

            x += meshVertex[i].x;
            y += meshVertex[i].y;
            z += meshVertex[i].z;

            //Debug.Log($"{this.gameObject.name} - Vertex {i}: [{meshVertex[i].x}, {meshVertex[i].y}, {meshVertex[i].z}]");
            count++;
        }

        MassScalar massCenter = new MassScalar(Math.Round(mass * ((x / count) + this.gameObject.transform.localPosition.x), 3),
        Math.Round(mass * ((y / count) + this.gameObject.transform.localPosition.y), 3),
        Math.Round(mass * ((z / count) + this.gameObject.transform.localPosition.z), 3));

        return massCenter;
    }
}

//Made because Vector3 keeps screwing me over with weird floating point errors.
public struct MassScalar
{
    public double x { get; }
    public double y { get; }
    public double z { get; }

    public MassScalar(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString() => $"[{x}, {y}, {z}]";
}
