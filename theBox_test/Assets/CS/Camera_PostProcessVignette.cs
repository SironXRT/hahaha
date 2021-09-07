using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class Camera_PostProcessVignette : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        vg = GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>();
    }

    Vignette vg;

    // Update is called once per frame
    void Update()
    {
        vg.intensity.value = Random.Range(0.3f, 0.46f);
    }
}
