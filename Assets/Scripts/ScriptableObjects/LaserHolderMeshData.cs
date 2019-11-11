using System;
using UnityEngine;

[Serializable]
public class MeshData
{
	public Mesh Mesh;
	public int[] VertexIndices;
}

[CreateAssetMenu(menuName = "Scriptable Objects/Laser Holder Mesh Data", fileName = "Laser Holder Mesh Data")]
public class LaserHolderMeshData : ScriptableObject
{
	public MeshData[] Data;

	public int[] this[Mesh lookup]
	{
		get
		{
			foreach (MeshData meshData in Data)
			{
				if (meshData.Mesh == lookup)
				{
					return meshData.VertexIndices;
				}
			}

			return null;
		}
	}
}