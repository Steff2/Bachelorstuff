#include "stdafx.h"

#include <list>
#include <map>
#include <stdexcept>
#include <utility>
#include <vector>
#include <sstream>
#include <math.h>
#include <map>
// Iostream - STD I/O Library
#include <iostream>

// fStream - STD File I/O Library
#include <fstream>

#include <string>

using namespace std;

namespace objl
{
	struct Vector2
	{
		// Default Constructor
		Vector2()
		{
			X = 0.0f;
			Y = 0.0f;
		}
		// Variable Set Constructor
		Vector2(float X_, float Y_)
		{
			X = X_;
			Y = Y_;
		}
		// Bool Equals Operator Overload
		bool operator==(const Vector2& other) const
		{
			return (this->X == other.X && this->Y == other.Y);
		}
		// Bool Not Equals Operator Overload
		bool operator!=(const Vector2& other) const
		{
			return !(this->X == other.X && this->Y == other.Y);
		}
		// Addition Operator Overload
		Vector2 operator+(const Vector2& right) const
		{
			return Vector2(this->X + right.X, this->Y + right.Y);
		}
		// Subtraction Operator Overload
		Vector2 operator-(const Vector2& right) const
		{
			return Vector2(this->X - right.X, this->Y - right.Y);
		}
		// Float Multiplication Operator Overload
		Vector2 operator*(const float& other) const
		{
			return Vector2(this->X *other, this->Y * other);
		}

		// Positional Variables
		float X;
		float Y;
	};

	// Structure: Vector3
		//
		// Description: A 3D Vector that Holds Positional Data
	struct Vector3
	{
		// Default Constructor
		Vector3()
		{
			X = 0.0f;
			Y = 0.0f;
			Z = 0.0f;
		}
		// Variable Set Constructor
		Vector3(float X_, float Y_, float Z_)
		{
			X = X_;
			Y = Y_;
			Z = Z_;
		}
		// Bool Equals Operator Overload
		bool operator==(const Vector3& other) const
		{
			return (this->X == other.X && this->Y == other.Y && this->Z == other.Z);
		}
		// Bool Not Equals Operator Overload
		bool operator!=(const Vector3& other) const
		{
			return !(this->X == other.X && this->Y == other.Y && this->Z == other.Z);
		}
		// Addition Operator Overload
		Vector3 operator+(const Vector3& right) const
		{
			return Vector3(this->X + right.X, this->Y + right.Y, this->Z + right.Z);
		}
		// Subtraction Operator Overload
		Vector3 operator-(const Vector3& right) const
		{
			return Vector3(this->X - right.X, this->Y - right.Y, this->Z - right.Z);
		}
		// Float Multiplication Operator Overload
		Vector3 operator*(const float& other) const
		{
			return Vector3(this->X * other, this->Y * other, this->Z * other);
		}
		// Float Division Operator Overload
		Vector3 operator/(const float& other) const
		{
			return Vector3(this->X / other, this->Y / other, this->Z / other);
		}

		// Positional Variables
		float X;
		float Y;
		float Z;
	};

	// Structure: Vertex
	//
	// Description: Model Vertex object that holds
	//	a Position, Normal, and Texture Coordinate
	struct Vertex
	{
		// Position Vector
		Vector3 Position;

		// Normal Vector
		Vector3 Normal;

		// Texture Coordinate Vector
		Vector2 TextureCoordinate;
	};

	struct Mesh
	{
		// Default Constructor
		Mesh()
		{

		}
		// Variable Set Constructor
		Mesh(std::vector<Vertex>& _Vertices, std::vector<unsigned int>& _Indices, std::vector<vector<int>>& _Triangles, std::vector<vector<int>> _VertexInTriangles)
		{
			Vertices = _Vertices;
			Indices = _Indices;
			Triangles = _Triangles;
			VertexInTriangles = _VertexInTriangles;
		}
		// Mesh Name
		std::string MeshName;
		// Vertex List
		std::vector<Vertex> Vertices;
		// Index List
		std::vector<unsigned int> Indices;
		//Triangles List
		std::vector<vector<int>> Triangles;
		std::vector<vector<int>> VertexInTriangles;
	};

	// Namespace: Algorithm
	//
	// Description: The namespace that holds all of the
	// Algorithms needed for OBJL
	namespace algorithm
	{
		// Vector3 Multiplication Opertor Overload
		Vector3 operator*(const float& left, const Vector3& right)
		{
			return Vector3(right.X * left, right.Y * left, right.Z * left);
		}

		// Split a String into a string array at a given token
		inline void split(const std::string &in,
			std::vector<std::string> &out,
			std::string token)
		{
			out.clear();

			std::string temp;

			for (int i = 0; i < int(in.size()); i++)
			{
				std::string test = in.substr(i, token.size());

				if (test == token)
				{
					if (!temp.empty())
					{
						out.push_back(temp);
						temp.clear();
						i += (int)token.size() - 1;
					}
					else
					{
						out.push_back("");
					}
				}
				else if (i + token.size() >= in.size())
				{
					temp += in.substr(i, token.size());
					out.push_back(temp);
					break;
				}
				else
				{
					temp += in[i];
				}
			}
		}

		// Get tail of string after first token and possibly following spaces
		inline std::string tail(const std::string &in)
		{
			size_t token_start = in.find_first_not_of(" \t");
			size_t space_start = in.find_first_of(" \t", token_start);
			size_t tail_start = in.find_first_not_of(" \t", space_start);
			size_t tail_end = in.find_last_not_of(" \t");
			if (tail_start != std::string::npos && tail_end != std::string::npos)
			{
				return in.substr(tail_start, tail_end - tail_start + 1);
			}
			else if (tail_start != std::string::npos)
			{
				return in.substr(tail_start);
			}
			return "";
		}

		// Get first token of string
		inline std::string firstToken(const std::string &in)
		{
			if (!in.empty())
			{
				size_t token_start = in.find_first_not_of(" \t");
				size_t token_end = in.find_first_of(" \t", token_start);
				if (token_start != std::string::npos && token_end != std::string::npos)
				{
					return in.substr(token_start, token_end - token_start);
				}
				else if (token_start != std::string::npos)
				{
					return in.substr(token_start);
				}
			}
			return "";
		}

		// Get element at given index position
		template <class T>
		inline const T & getElement(const std::vector<T> &elements, std::string &index)
		{
			int idx = std::stoi(index);
			if (idx < 0)
				idx = int(elements.size()) + idx;
			else
				idx--;
			return elements[idx];
		}
	}

	class obj_read
	{
	public:

		obj_read()
		{

		}

		bool loadfile(std::string Path)
		{

			std::ifstream file(Path);

			if (!file.is_open())
				return false;

			std::string meshname;

			Mesh tempMesh;

			std::string curline;

			std::vector<Vector3> Positions;
			std::vector<Vector2> TCoords;
			std::vector<Vector3> Normals;

			std::vector<Vertex> Vertices;
			std::vector<unsigned int> Indices;
			std::vector<vector<int>> Triangles;
			std::vector<vector<int>> VertexInTriangle;
			int TriangleCounter = 1;

			std::map<unsigned int, bool> TriangleDict;

			while (std::getline(file, curline))
			{

				// Generate a Vertex Position
				if (algorithm::firstToken(curline) == "v")
				{
					std::vector<std::string> spos;
					Vector3 vpos;
					algorithm::split(algorithm::tail(curline), spos, " ");

					vpos.X = std::stof(spos[0]);
					vpos.Y = std::stof(spos[1]);
					vpos.Z = std::stof(spos[2]);

					Positions.push_back(vpos);
				}
				// Generate a Vertex Texture Coordinate
				if (algorithm::firstToken(curline) == "vt")
				{
					std::vector<std::string> stex;
					Vector2 vtex;
					algorithm::split(algorithm::tail(curline), stex, " ");

					vtex.X = std::stof(stex[0]);
					vtex.Y = std::stof(stex[1]);

					TCoords.push_back(vtex);
				}
				// Generate a Vertex Normal;
				if (algorithm::firstToken(curline) == "vn")
				{
					std::vector<std::string> snor;
					Vector3 vnor;
					algorithm::split(algorithm::tail(curline), snor, " ");

					vnor.X = std::stof(snor[0]);
					vnor.Y = std::stof(snor[1]);
					vnor.Z = std::stof(snor[2]);

					Normals.push_back(vnor);
				}
				// Generate a Face (vertices & indices)
				if (algorithm::firstToken(curline) == "f")
				{
					// Generate the vertices
					std::vector<Vertex> vVerts;
					GenVerticesFromRawOBJ(vVerts, Indices, LoadedIndices, Triangles, Positions, TCoords, Normals, curline, TriangleCounter, VertexInTriangle);
					TriangleCounter++;
					// Add Vertices
					for (int i = 0; i < int(vVerts.size()); i++)
					{
						Vertices.push_back(vVerts[i]);

						LoadedVertices.push_back(vVerts[i]);
					}
				}
			}

			if (!Indices.empty() && !Vertices.empty())
			{
				// Create Mesh
				tempMesh = Mesh(Vertices, Indices, Triangles, VertexInTriangle);

				// Insert Mesh
				LoadedMeshes.push_back(tempMesh);
			}

			file.close();
		}
			// Loaded Mesh Objects
			std::vector<Mesh> LoadedMeshes;
			// Loaded Vertex Objects
			std::vector<Vertex> LoadedVertices;
			// Loaded Index Positions
			std::vector<unsigned int> LoadedIndices;

	private:
			// Generate vertices from a list of positions, 
			//	tcoords, normals and a face line
			void GenVerticesFromRawOBJ(std::vector<Vertex>& oVerts,
				std::vector<unsigned int>& oIndices,
				std::vector<unsigned int>& LoadIndices,
				std::vector<vector<int>>& Triangles,
				const std::vector<Vector3>& iPositions,
				const std::vector<Vector2>& iTCoords,
				const std::vector<Vector3>& iNormals,
				std::string icurline,
				int TriangleCounter,
				std::vector<vector<int>> VertexInTriangle
				)
			{
				std::vector<std::string> sface, svert;
				Vertex vVert;
				algorithm::split(algorithm::tail(icurline), sface, " ");

				bool noNormal = false;

				// For every given vertex do this
				for (int i = 0; i < int(sface.size()); i++)
				{
					// See What type the vertex is.
					int vtype;

					algorithm::split(sface[i], svert, "/");

					// Check for just position - v1
					if (svert.size() == 1)
					{
						// Only position
						vtype = 1;
					}

					// Check for position & texture - v1/vt1
					if (svert.size() == 2)
					{
						// Position & Texture
						vtype = 2;
					}

					// Check for Position, Texture and Normal - v1/vt1/vn1
					// or if Position and Normal - v1//vn1
					if (svert.size() == 3)
					{
						if (svert[1] != "")
						{
							// Position, Texture, and Normal
							vtype = 4;
						}
						else
						{
							// Position & Normal
							vtype = 3;
						}
					}

					// Calculate and store the vertex
					switch (vtype)
					{
					case 1: // P
					{
						vVert.Position = algorithm::getElement(iPositions, svert[0]);
						vVert.TextureCoordinate = Vector2(0, 0);
						noNormal = true;
						oVerts.push_back(vVert);
						break;
					}
					case 2: // P/T
					{
						vVert.Position = algorithm::getElement(iPositions, svert[0]);
						vVert.TextureCoordinate = algorithm::getElement(iTCoords, svert[1]);
						noNormal = true;
						oVerts.push_back(vVert);
						break;
					}
					case 3: // P//N
					{
						Triangles[std::stoi(svert[0])].push_back(TriangleCounter);
						VertexInTriangle[i].push_back(std::stoi(svert[0]));
						vVert.Position = algorithm::getElement(iPositions, svert[0]);
						vVert.TextureCoordinate = Vector2(0, 0);
						vVert.Normal = algorithm::getElement(iNormals, svert[2]);
						oVerts.push_back(vVert);
						break;
					}
					case 4: // P/T/N
					{
						vVert.Position = algorithm::getElement(iPositions, svert[0]);
						vVert.TextureCoordinate = algorithm::getElement(iTCoords, svert[1]);
						vVert.Normal = algorithm::getElement(iNormals, svert[2]);
						oVerts.push_back(vVert);
						break;
					}
					default:
					{
						break;
					}
					}
				}
			}
	};
}