using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextureMapper : MonoBehaviour
{
    private Renderer rend;
    public float scaleXIn = 1;
    public float scaleYin = 1;
    float scaleX;
    float scaleY;
    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<Renderer>();
        foreach (var propertyName in rend.material.GetTexturePropertyNames())
        {
            Debug.Log(propertyName);
        }
       
        Debug.Log($"{scaleX}:{scaleY}");
        var scale = scaleXIn / scaleYin;
        scaleX = transform.localScale.x * scale;
        scaleY = transform.localScale.y * scale;
        // scaleY = 1;
        // foreach (var material in rend.materials)
        // {
        //     Debug.Log($"{material.name} - {material.}");
        // }
        // Debug.Log(rend.material.mainTexture.ToString());

        // Debug.Log(Shader.PropertyToID("_MainText"));

    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetTextureScale("_EmissionMap", new Vector2(scaleX, scaleY));
        rend.material.SetTextureScale("_BaseMap", new Vector2(scaleX, scaleY));
        
        // rend.material.SetTextureScale("_MainTex", new Vector2(2,4));
    }
}
