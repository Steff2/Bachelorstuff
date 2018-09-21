// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"

// Example 1: Load and Print
//
// Load the data from the .obj then print it into a file
//	called e1Out.txt

#include <list>

#include <map>

#include <utility>

// Iostream - STD I/O Library
#include <iostream>

// fStream - STD File I/O Library
#include <fstream>

// OBJ_Loader - .obj Loader
#include "OBJ_Loader.h"

//obj writer
#include "obj_io.h"

#include <string>

// Main function
int main(int argc, char* argv[])
{
	// Initialize Loader
	objl::Loader Loader;

	std::map<int, bool> TriangleDict;
	// Load .obj File
	bool loadout = Loader.LoadFile("FullSurfaceLessthanOneThird.obj");

	// Check to see if it loaded

	// If so continue
	if (loadout)
	{
			// Go through each loaded mesh and out its contents
			for (int i = 0; i < Loader.LoadedMeshes.size(); i++)
			{
				// Copy one of the loaded meshes to be our current mesh
				objl::Mesh curMesh = Loader.LoadedMeshes[i];

				// Print Mesh Name
				file << "Mesh " << i << ": " << curMesh.MeshName << "\n";

				// Print Vertices
				file << "Vertices:\n";

				// Go through each vertex and print its number,
				//  position, normal, and texture coordinate
				file << "o Split Mesh" << "\n";

				std::array<std::list<int>, curMesh.Vertices.size()> VertexToTriangle;

				// Go through every 3rd index and print the
				//	triangle that these indices represent
				for (int j = 0; j < VertexToTriangle.size() / 5000000; j++)
				{
					int x = j;
					// Create/Open e1Out.txt
					std::ofstream file("SplitMeshes" << x << ".obj");


						for (int j = 0; j < curMesh.Vertices.size() / 3; j++)
						{
							VertexToTriangle[j].push_front(j);
							VertexToTriangle[j + 1].push_front(j);
							VertexToTriangle[j + 2].push_front(j);
						}

					
					list<int> face_node;

					for (int i = 0; i < 20; i++)
					{
						for (std::list<int>::iterator it = VertexToTriangle[i].begin(); it != VertexToTriangle[i].end(); ++it)
						{
							if (TriangleDict.find(it) == true)
								continue;

							else {
								mymap.insert(std::pair<int, bool>(it, true));
								face_node.insert(j * i, curMesh.Indices[it * 3]);
								face_node.insert(j * i + 1, curMesh.Indices[(it * 3) - 1]);
								face_node.insert(j * i + 2, curMesh.Indices[(it * 3) - 2]);


							}
						}
						int face_node_array[face_node.size()];
						for (std::list<int>::iterator it = face_node.begin(); it != face_node.end(); ++it)
						{
							face_node_array[i] = *it;
						}
						int face_num = face_node.size() / 3;
						int face_order[face_num];
						for (int l = 0; l < face_node.size(); l++)
						{
							face_order[l] = 3;
						}
						int node_num = curMesh.Vertices.size();
						double node_xyz[node_num];
						int normal_vector[curMesh.Vertices.size()];
						int vertex_normal[curMesh.Vertices.size()];
						for (int k = 0; k < curMesh.Indices.size(); k++)
						{
							node_xyz[k] = curMesh.Vertices[k].Position;
							normal_vector[k] = curMesh.Vertices[k].Normal;
							vertex_normal[k] = k;

						}
					}




				/*file << "T" << j / 3 << ": " << curMesh.Indices[j] << ", " << curMesh.Indices[j + 1] << ", " << curMesh.Indices[j + 2] << "\n";

				file << "V" << j << ": " <<
					"P(" << curMesh.Vertices[j].Position.X << ", " << curMesh.Vertices[j].Position.Y << ", " << curMesh.Vertices[j].Position.Z << ") " <<
					"N(" << curMesh.Vertices[j].Normal.X << ", " << curMesh.Vertices[j].Normal.Y << ", " << curMesh.Vertices[j].Normal.Z << ") " <<
					"TC(" << curMesh.Vertices[j].TextureCoordinate.X << ", " << curMesh.Vertices[j].TextureCoordinate.Y << ")\n";*/
				}

			// Leave a space to separate from the next mesh
			file << "\n";

			//obj_write(output_filename, node_num, face_num, normal_num,
				//order_max, node_xyz, face_order, face_node, normal_vector, vertex_normal);
			}

		// Close File
		file.close();
	}
	// If not output an error
	else
	{
		// Create/Open e1Out.txt
		std::ofstream file("SplitMeshes.obj");

		// Output Error
		file << "Failed to Load File. May have failed to find it or it was not an .obj file.\n";

		// Close File
		file.close();
	}

	// Exit the program
	return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file

