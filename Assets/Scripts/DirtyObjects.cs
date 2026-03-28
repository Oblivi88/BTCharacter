using UnityEngine;

public class DirtyObjects : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private float dirtLevel;
    public float dirtSpeed;

    private Color cleanColor = Color.white;
    private Color dirtyColor = Color.black;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirtLevel += Time.deltaTime * dirtSpeed;
        if (dirtLevel > 1)
        {
            dirtLevel = 1;
        }

        meshRenderer.material.color = Color.Lerp(cleanColor, dirtyColor, dirtLevel);
    }
}
