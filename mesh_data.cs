using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class mesh_data 
{
    public static Vector3[] vertices = new Vector3[]
    {
        new Vector3(1,1,1),
        new Vector3(-1,1,1),
        new Vector3(-1,-1,1),
        new Vector3(1,-1,1),
        new Vector3(-1,1,-1),
        new Vector3(1,1,-1),
        new Vector3(1,-1,-1),
        new Vector3(-1,-1,-1)

    };
    public static int[][] facetriangles =
    {
        new int[]{0,1,2,3},
        new int[]{5,0,3,6},
        new int[]{4,5,6,7},
        new int[]{1,4,7,2},
        new int[]{5,4,1,0},
        new int[]{3,2,7,6}
    };
    public static Vector3[] facevertices(int direction)
    {
        Vector3[] tm = new Vector3[4];
        for (int i = 0; i < tm.Length; i++)
        {
            tm[i] = vertices[facetriangles[direction][i]];
        }
        return tm;
    }


}
