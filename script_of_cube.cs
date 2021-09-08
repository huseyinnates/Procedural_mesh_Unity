using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class script_of_cube : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    // Start is called before the first frame update
    void Start()
    {
        // MakeDiscreteGrid();
        MakeCube();
        UpdateMesh();
    }
    void MakeCube()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i);
        }
    }
    void MakeFace(int dir)
    {
        vertices.AddRange(mesh_data.facevertices(dir));
        int vcount = vertices.Count;

        triangles.Add(vcount - 4+0);
        triangles.Add(vcount - 4+1);
        triangles.Add(vcount - 4+2);
        triangles.Add(vcount - 4+0);
        triangles.Add(vcount - 4+2);
        triangles.Add(vcount - 4+3);
    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }

}
