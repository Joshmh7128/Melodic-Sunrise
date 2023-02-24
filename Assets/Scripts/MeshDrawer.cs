using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDrawer : MonoBehaviour
{
    [SerializeField] List<Vector3> vertices = new List<Vector3>(); // vert list
    [SerializeField] Mesh mesh;
    [SerializeField] List<int> triangles = new List<int>(); // tri list

    // start runs on the start of the object
    private void Start()
    {
        // create a new mesh
        mesh = new Mesh();

        // draw the mesh
        DrawMesh();

        // set the mesh
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
    }

    // draw a mesh
    void DrawMesh()
    {
        // clear our lists
        triangles.Clear();
        vertices.Clear();

        // get our vertices from our children
        for (int c = 0; c < transform.childCount; c++)
        {
            vertices.Add(transform.GetChild(c).position);
        }

        // then add vertices to itself backward
        List<Vector3> backVerts = new List<Vector3>();
        foreach (Vector3 v in vertices)
        {
            backVerts.Add(v);
        }
        
        for (int z = backVerts.Count - 1; z > 0; z--)
        {
            vertices.Add(backVerts[z]);
        }

        // set verts
        mesh.SetVertices(vertices);

        // set up our tris
        // for each vertex, draw a tri to every 3 vertices
        // we are dividing by 2 because we are rendering a 2 sided mesh
        for (int i = 0; i < vertices.Count - 1; i += 3)
        {
            for (int j = 0; j < vertices.Count - 1; j++)
            {
                // add i, j+1, j+2
                triangles.Add(i);
                if (j != i)
                    triangles.Add(j);
                if (j + 1 != i)
                    triangles.Add(j + 1);
            }
        }

        // ensure we set the triangle count to a multiple of 3
        while (triangles.Count % 3 != 0)
        {
            triangles.Add(0);
        }

        // set tris
        mesh.SetTriangles(triangles.ToArray(), 0, triangles.Count, 0, true, 0);

        // recalculate normals
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    private void FixedUpdate()
    {
        DrawMesh();
    }
}

