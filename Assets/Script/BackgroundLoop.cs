using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material material;
    public static bool Kondisi;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Kondisi == false)
            offset += (Time.deltaTime * scrollSpeed) / 10f;

        else
            offset = 0;

        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
