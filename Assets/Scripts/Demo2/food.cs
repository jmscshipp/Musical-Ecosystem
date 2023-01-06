using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public int minNutrients, maxNutrients;
    private int nutrients;
    private float scale;
   
    // outline expand visual effect
    private Transform outline;
    private float outlineStartScale;

    // lerp size on entry visual effect
    private bool entrySizeLerp;
    private float lerp;

    void Start()
    {
        nutrients = Random.Range(minNutrients, maxNutrients);
        scale = nutrients / 10f;

        outline = transform.Find("outlineGraphics");
        outlineStartScale = outline.localScale.x;

        entrySizeLerp = true;
        lerp = 0.0f;
    }

    void Update()
    {
        if (entrySizeLerp)
        {
            lerp += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(scale, scale, 1), lerp);
            if (lerp >= 1.0f)
                entrySizeLerp = false;
        }

        OutlineExpand(Mathf.Sin(Time.time));
    }

    void OutlineExpand(float outlineScale)
    {
        // converts from (-1 to 1) to (0 to 1/2 of startScale)
        float scale = outlineStartScale + ((outlineScale + 1.0f) / 2.0f) * outlineStartScale / 4.0f;
        outline.localScale = new Vector3(scale, scale, 1.0f);
    }
}
