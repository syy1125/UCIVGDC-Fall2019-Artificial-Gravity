using UnityEngine;

public class ShaderRendererControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var block = new MaterialPropertyBlock();
            var r = GetComponent<Renderer>();
            r.GetPropertyBlock(block);
            Debug.Log(block.GetFloat("_OutlineActive"));
            block.SetFloat("_OutlineActive", 1 - block.GetFloat("_OutlineActive"));
            r.SetPropertyBlock(block);
        }
    }
}
