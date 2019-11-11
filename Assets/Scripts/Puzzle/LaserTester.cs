using UnityEngine;

public class LaserTester : MonoBehaviour
{
	public int[] VertexIndices;

	private void OnDrawGizmos()
	{
		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
		Transform t = transform;
		Gizmos.color = Color.red;

		foreach (int index in VertexIndices)
		{
			if (index >= 0 && index < mesh.vertexCount)
			{
				Gizmos.DrawWireSphere(
					t.TransformPoint(mesh.vertices[index]),
					0.02f
				);
			}
		}
	}
}