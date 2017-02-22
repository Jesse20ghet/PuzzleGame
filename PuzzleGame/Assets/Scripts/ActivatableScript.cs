using UnityEngine;

public class ActivatableScript : MonoBehaviour
{
	new Renderer renderer;
	Shader startingShader;
	Shader highlightShader;

	void Start()
	{
		highlightShader = Shader.Find("Legacy Shaders/Self-Illumin/VertexLit");

		renderer = GetComponent<Renderer>();
		startingShader = renderer.material.shader;
	}

	public void OnMouseOver()
	{
		if (Vector3.Distance(transform.position, Camera.main.transform.position) <= 5)
		{
			renderer.material.shader = highlightShader;
		}
		else
			renderer.material.shader = startingShader;
	}

	public void OnMouseExit()
	{
		Debug.Log("Mouse Exited");
		renderer.material.shader = startingShader;
	}
}
