using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshSplitter : MonoBehaviour {

    //public int Splitcount = 1000;
    //Dictionary to make sure you don't get duplicate points
    List<Vector3> CountingVertexList = new List<Vector3>();
    Dictionary<int, Vector3> adjacentVertices = new Dictionary<int, Vector3>();

    public int Neighbourcount = 1;

    void Start()
    {
        Mesh Curmesh = GetComponent<MeshFilter>().mesh;

        CountingVertexList.Capacity = Curmesh.vertexCount;

        while(CountingVertexList.Count < Curmesh.vertexCount)
        {
            int i = 1;
            //Erstellen der neuen Meshes
            GameObject MeshHolder = new GameObject();
            MeshHolder.AddComponent<MeshFilter>();
            //MeshHolder.AddComponent<MeshRenderer>();
            MeshHolder.AddComponent<MeshCollider>();

            Mesh newMesh = MeshHolder.GetComponent<MeshFilter>().mesh;

            GetNeighbors(Curmesh, i, newMesh);

            i++;
        }
    }

    Vector3[] GetNeighbors(Mesh meshX, int index, Mesh newMesh)
    {
        //Platzhalter Arrays für das neue Mesh
        int[] NewMeshIndices = new int[10000];
        int[] NewMeshTriangles = new int[2000];
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
                    int adjacentIndex = meshX.triangles[i * 3 + j];
                    int adjacentIndextoVertex = meshX.GetIndices(0)[adjacentIndex];
                    if (adjacentVertices.ContainsKey(adjacentIndex) == false)
                    {
                        CountingVertexList.Add(meshX.vertices[adjacentIndex]);
                        adjacentVertices.Add(adjacentIndex, meshX.vertices[adjacentIndex]);
                        //Hier versuchen die sachen in das neue Mesh zu bringen also index und triangles.
                        NewMeshTriangles[ArrayIndexingCounter] = adjacentIndex;
                        NewMeshIndices[adjacentIndex] = adjacentIndextoVertex;
                        newMeshVertices.Insert(ArrayIndexingCounter, meshX.vertices[adjacentIndex]);
                        ArrayIndexingCounter++;
                        if (adjacentIndex != index)
                        {
                            while(Neighbourcount != 10)
                            {
                                Neighbourcount++;
                                GetNeighbors(meshX, adjacentIndex, newMesh);
                            }
                        }
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
