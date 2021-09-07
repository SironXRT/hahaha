using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationTimeRewinder : MonoBehaviour
{
    public float recordLength = 30;
    public bool usingRigidbody = false;

    List<Quaternion> RotationRecorder;
    bool isRewinding = false;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        RotationRecorder = new List<Quaternion>();
        if (usingRigidbody) rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Q))
            StopRewind();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Rewind()
    {
        if (RotationRecorder.Count > 0)
        {
            GetComponent<RectTransform>().rotation = RotationRecorder[0];
            RotationRecorder.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if (RotationRecorder.Count > Mathf.RoundToInt(recordLength / Time.fixedDeltaTime))
        {
            RotationRecorder.RemoveAt(RotationRecorder.Count - 1);
        }

        RotationRecorder.Insert(0, GetComponent<RectTransform>().rotation);
    }

    void StartRewind()
    {
        GetComponent<CopyBox_2D>().enabled = false;
        isRewinding = true;
        if (usingRigidbody) rb.simulated = false;
    }

    void StopRewind()
    {
        GetComponent<CopyBox_2D>().enabled = true;
        isRewinding = false;
        if (usingRigidbody) rb.simulated = true;
    }
}
