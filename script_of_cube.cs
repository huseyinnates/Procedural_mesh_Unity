using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class script_of_cube : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;//unknown size

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
    //we declare after define the ver and tri but not as array cause of we dont know how many variable we deal with
    //call the makeface for 6 times 
    void MakeCube()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i);
        }
    }
    int a = 0;
    //taking information of face quad order 
    // add range useful for adding every call to new var
    //we store the count info;
    //after we arrange these to draw triangles
    void MakeFace(int dir)
    {
        vertices.AddRange(mesh_data.facevertices(dir));
        int vcount = vertices.Count;
        print(vcount);
        print(a);
        triangles.Add(vcount - 4+0);
        triangles.Add(vcount - 4+1);
        triangles.Add(vcount - 4+2);
        triangles.Add(vcount - 4+0);
        triangles.Add(vcount - 4+2);
        triangles.Add(vcount - 4+3);
        a++;
    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }

}
