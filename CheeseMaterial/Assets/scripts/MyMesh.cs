using UnityEngine;
using System.Collections;

public class MyMesh : MonoBehaviour {
	public Transform A;
	public Transform B;
	public Transform C;
	public Transform D;
	public Material CheeseMaterial;


	// Use this for initialization
	void Start () {
//		Vector3[] newVertices = {A.position, B.position, C.position};
//		int[] newTriangles = {0,1,2};
//		Mesh mesh = new Mesh();
//		mesh.vertices = newVertices;
//		mesh.triangles = newTriangles;

		var meshFilter = gameObject.AddComponent<MeshFilter> ();
		var meshRenderer = gameObject.AddComponent<MeshRenderer> ();
		meshRenderer.material = CheeseMaterial;
//		meshFilter.mesh = mesh;
	}

	void Update() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] newVertices = {A.position, B.position, C.position, D.position};
		int[] newTriangles = {0,1,2,0,2,3};
		Vector2[] newUV = {
			new Vector2(0,0),
			new Vector2(0,1),
			new Vector2(1,1),
			new Vector2(1,0)
		};

		mesh.vertices = newVertices;
		mesh.triangles = newTriangles;
		mesh.uv = newUV;
		mesh.RecalculateNormals ();
	}

	void Update1() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		int i = 0;
		while (i < vertices.Length) {
			vertices[i] += normals[i] * Mathf.Sin(Time.time);
			i++;
		}
		mesh.vertices = vertices;
	}

	void OnMouseDown1() {
		var mesh = GetComponent<MeshFilter> ().mesh;
		Vector3[] vertices = mesh.vertices;
		for (int i=0;i<vertices.Length;i++) {
			var v=vertices[i];
			var b = object.ReferenceEquals(vertices[i],v);
			Debug.Log(v.x +","+ v.y +","+ v.z + "\r\n");
			vertices[i]*=2;
		}
		mesh.vertices = vertices;
	}
}
