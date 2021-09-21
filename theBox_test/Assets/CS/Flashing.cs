using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Flashing : MonoBehaviour
{
    public float Flash_Time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        yield return new WaitForSecondsRealtime(Flash_Time);
        GetComponent<Text>().enabled = false;
        yield return new WaitForSecondsRealtime(Flash_Time);
        GetComponent<Text>().enabled = true;
        StartCoroutine(Flash());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
