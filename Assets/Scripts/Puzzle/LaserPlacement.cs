using UnityEngine;

[ExecuteInEditMode]
public class LaserPlacement : MonoBehaviour
{
	[Header("References")]
	public MeshFilter FirstMesh;
	public MeshFilter SecondMesh;
	public LaserHolderMeshData MeshData;
	public LineRenderer[] LaserRenderers;

	private void Start()
	{
		if (!Application.isEditor)
		{
			PositionRenderers();
			foreach (LineRenderer renderer in LaserRenderers)
			{
				renderer.enabled = true;
			}
		}
	}

	private void Update()
	{
		if (Application.isEditor)
		{
			PositionRenderers();
		}
	}

	private void PositionRenderers()
	{
		if (FirstMesh == null || SecondMesh == null || MeshData == null) return;
		int[] firstIndices = MeshData[FirstMesh.sharedMesh];
		int[] secondIndices = MeshData[SecondMesh.sharedMesh];
		if (firstIndices == null)
		{
			Debug.LogError("Failed to do lookup for " + FirstMesh.sharedMesh.name);
			return;
		}

		if (secondIndices == null)
		{
			Debug.LogError("Failed to do lookup for " + SecondMesh.sharedMesh.name);
			return;
		}

		for (int i = 0; i < 5 && i < LaserRenderers.Length; i++)
		{
			if (LaserRenderers[i] == null) continue;

			Transform rendererTransform = LaserRenderers[i].transform;
			Vector3 firstPoint = FirstMesh.transform.TransformPoint(FirstMesh.sharedMesh.vertices[firstIndices[i]]);
			Vector3 secondPoint = SecondMesh.transform.TransformPoint(SecondMesh.sharedMesh.vertices[secondIndices[i]]);

			rendererTransform.rotation = Quaternion.LookRotation(secondPoint - firstPoint);
			rendererTransform.Rotate(rendererTransform.up, 90);
			rendererTransform.position = firstPoint / 2 + secondPoint / 2;
			rendererTransform.localScale = new Vector3(
				rendererTransform.parent.InverseTransformVector(firstPoint - secondPoint).magnitude,
				1, 1
			);
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (FirstMesh == null || SecondMesh == null || MeshData == null) return;
		int[] firstIndices = MeshData[FirstMesh.sharedMesh];
		int[] secondIndices = MeshData[SecondMesh.sharedMesh];
		if (firstIndices == null || secondIndices == null) return;

		Transform firstTransform = FirstMesh.transform;
		Transform secondTransform = SecondMesh.transform;

		Gizmos.color = Color.red;
		for (int i = 0; i < firstIndices.Length && i < secondIndices.Length; i++)
		{
			Vector3 firstPosition = firstTransform.TransformPoint(FirstMesh.sharedMesh.vertices[firstIndices[i]]);
			Vector3 secondPosition = secondTransform.TransformPoint(SecondMesh.sharedMesh.vertices[secondIndices[i]]);
			Gizmos.DrawWireSphere(firstPosition, 0.02f);
			Gizmos.DrawWireSphere(secondPosition, 0.02f);
			Gizmos.DrawLine(firstPosition, secondPosition);
		}
	}
}