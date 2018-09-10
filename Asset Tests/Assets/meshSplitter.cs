using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshSplitter : MonoBehaviour {

    public int Splitcount = 1000;
    //Dictionary to make sure you don't get duplicate points
    Dictionary<int, Vector3> adjacentVertices = new Dictionary<int, Vector3>();

    void Start()
    {
        Mesh Curmesh = GetComponent<MeshFilter>().mesh;

        for (int i = 0; i < Splitcount; i++)
        {
            //Erstellen der neuen Meshes
            GameObject MeshHolder = new GameObject();
            MeshHolder.AddComponent<MeshFilter>();
            //MeshHolder.AddComponent<MeshRenderer>();
            MeshHolder.AddComponent<MeshCollider>();

            Mesh newMesh = MeshHolder.GetComponent<MeshFilter>().mesh;

            GetNeighbors(Curmesh, i, newMesh);

        }
    }

    Vector3[] GetNeighbors(Mesh meshX, int index, Mesh newMesh)
    {
        //Platzhalter Arrays für das neue Mesh
        int[] NewMeshIndices = new int[meshX.GetIndexCount(0) / Splitcount];
        int[] NewMeshTriangles = new int[meshX.triangles.Length / Splitcount * 3];
        List<Vector3> newMeshVertices = new List<Vector3>();

        int ArrayIndexingCounter = 0;
        for (int i = 0; i < meshX.triangles.Length / 3; i++)
        {
            // see if the triangle contains the index
            bool found = false;
            for (int j = 0; j < 3; j++)
            {
                int cur = meshX.triangles[i * 3 + j];
                if (cur == index) found = true;
            }
            // if we found the index in the triangle, append the others.
            if (found)
            {
                for (int j = 0; j < 3; j++)
                {
                    int adjacent = meshX.triangles[i * 3 + j];
                    int adjacentIndextoVertex = meshX.GetIndices(0)[adjacent];
                    if (adjacentVertices.ContainsKey(adjacent) == false)
                    {
                        adjacentVertices.Add(adjacent, meshX.vertices[adjacent]);
                        //Hier versuchen die sachen in das neue Mesh zu bringen also index und triangles.
                        NewMeshTriangles[ArrayIndexingCounter] = adjacent;
                        NewMeshIndices[adjacent] = adjacentIndextoVertex;
                        newMeshVertices[ArrayIndexingCounter] = meshX.vertices[adjacent];
                        ArrayIndexingCounter++;
                        //Hier eventuell den Nachbar von dem Nachbar suchen durch nochmaligen Aufruf der funktion mit adjacent und for-schleife
                    }

                }
            }
        }
        newMesh.SetTriangles(NewMeshTriangles, 0);
        newMesh.SetIndices(NewMeshIndices, MeshTopology.Triangles, 0);
        newMesh.SetVertices(newMeshVertices);
        //Hier Platzhalter return
        return meshX.vertices;
    }
}
