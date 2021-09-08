using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural : MonoBehaviour
{
  
    
    private void Awake()
    {
        Mesh pmesh = new Mesh();
        pmesh.name = "Pro_mesh";
        MeshFilter mf = GetComponent<MeshFilter>();
        Vector3[] vertices = new Vector3[]
        {
        new Vector3(-1,1),//0
        new Vector3(1,1),//1
        new Vector3(1,-1),//2
        new Vector3(-1,-1),//3
        new Vector3(-1,1,2),//4
        new Vector3(-1,-1,2),//5
        new Vector3(1,1,2),//6
        new Vector3(1,-1,2),//7

        };
        int[] triangles = new int[]
        {
        0,1,3,
        3,1,2,
        3,0,5,
        0,4,5,
        4,6,7,
        5,4,7,
        1,6,7,
        2,1,7,
        5,4,1,
        4,6,1,
        3,5,2,
        5,7,2
        };
        pmesh.SetVertices(vertices);
        pmesh.triangles = triangles;
        mf.sharedMesh = pmesh;


    }
   
    
    



}
