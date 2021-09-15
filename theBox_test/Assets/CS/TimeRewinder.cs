using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRewinder : MonoBehaviour
{
    public float recordLength = 30;
    public bool usingRigidbody = false;

    BoxCollider2D bc2;

    List<Vector3> PositionRecorder;
    bool isRewinding = false;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        bc2 = GetComponent<BoxCollider2D>();
        PositionRecorder = new List<Vector3>();
        if (usingRigidbody) rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Rewind()
    {
        if (PositionRecorder.Count > 0)
        {
            GetComponent<RectTransform>().localPosition = PositionRecorder[1];
            PositionRecorder.RemoveAt(1);
        }
        else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if (PositionRecorder.Count > Mathf.RoundToInt(recordLength / Time.fixedDeltaTime))
        {
            PositionRecorder.RemoveAt(PositionRecorder.Count - 1);
        }
        PositionRecorder.Insert(0, GetComponent<RectTransform>().localPosition);
    }

    public void StartRewind()
    {
        isRewinding = true;
        if (usingRigidbody) rb.simulated = false;
        bc2.enabled = false;
    }

    public void StopRewind()
    {
        isRewinding = false;
        if (usingRigidbody) rb.simulated = true;
        bc2.enabled = true;
    }
}
