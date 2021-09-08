using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class grid : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;


    public float CellSize=1;
    public Vector3 GridOffset=new Vector3(0,0,0);
    public int GridSize=1;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    // Start is called before the first frame update
    void Start()
    {
        // MakeDiscreteGrid();
        MakeContiguousGrid();
        UpdateMesh();
    }

    /*
       void  MakeDiscreteGrid() {
            vertices = new Vector3[GridSize*GridSize*4];
            triangles = new int[GridSize*GridSize*6];

            //trackers
            int v = 0;
            int t = 0;
            int k = 0;
            float vertexoffset = CellSize * 0.5f;
            for(int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    k = 0;
                    Vector3 celloffset = new Vector3(x * CellSize, 0, y * CellSize);
                    vertices[0+v] = new Vector3(-vertexoffset, k, vertexoffset)+celloffset  + GridOffset;
                    vertices[1+v] = new Vector3(vertexoffset, k, vertexoffset) + celloffset  + GridOffset;
                    vertices[2+v] = new Vector3(vertexoffset, k, -vertexoffset) + celloffset + GridOffset;
                    vertices[3+v] = new Vector3(-vertexoffset, k, -vertexoffset) + celloffset + GridOffset;

                    triangles[0 + t] = 0+v;
                    triangles[1 + t] = 1+v;
                    triangles[2 + t] = 2+v;
                    triangles[3 + t] = 3+v;
                    triangles[4 + t] = 0+v;
                    triangles[5 + t] = 2+v;

                    t += 6;
                    v += 4;



                }

            }



        }*/
    void MakeContiguousGrid()
    {
        vertices = new Vector3[(GridSize + 1)* (GridSize + 1)];
        triangles = new int[GridSize*GridSize*6];

        //trackers
        int v = 0;
        int t = 0;
        float vertexoffset = CellSize * 0.5f;
        for (int x = 0; x <= GridSize; x++)
        {
            for (int y = 0; y <= GridSize; y++)
            {

                vertices[v] = new Vector3((x * CellSize) - vertexoffset, (x+y)*0.2f, (y * CellSize) - vertexoffset);
                v++;

            }

        }

        v = 0;

        for (int x = 0; x < GridSize; x++)
        {
            for (int y = 0; y < GridSize; y++)
            {
                triangles[t] = v+y;
                triangles[t + 1] = v + 1+y;
                triangles[t + 2] = GridSize + 1 + v+y;
                triangles[t + 3] = v + 1+y;
                triangles[t + 4] = GridSize + 2 + v+y;
                triangles[t + 5] = GridSize +1 +v+y;
                t += 6;
            }
            v+=GridSize+1;
        }



    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }


}
