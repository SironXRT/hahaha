using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionTimeRewinder : MonoBehaviour
{
    public AudioSource BackgroundMusic;
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
        if (PositionRecorder.Count > 0)
        {
            GetComponent<RectTransform>().localPosition = PositionRecorder[0];
            PositionRecorder.RemoveAt(0);
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

    void StartRewind()
    {
        BackgroundMusic.pitch = -1;
        isRewinding = true;
        if (usingRigidbody) rb.simulated = false;
        bc2.enabled = false;
    }

    void StopRewind()
    {
        BackgroundMusic.pitch = 1;
        isRewinding = false;
        if (usingRigidbody) rb.simulated = true;
        bc2.enabled = true;
    }
}
