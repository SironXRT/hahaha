using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShakeObject : MonoBehaviour
{
    public float speed;
    public float amount;
    Vector3 ogPosition;
    // Start is called before the first frame update
    void Start()
    {
        ogPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ogPosition.x + Mathf.Sin(Time.time * speed) * amount * Random.Range(-1f,1f), ogPosition.y + Mathf.Sin(Time.time * speed) * amount * Random.Range(-1f, 1f), ogPosition.z + Mathf.Sin(Time.time * speed) * amount * Random.Range(-1f, 1f));
    }
}
