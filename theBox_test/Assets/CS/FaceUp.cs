using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUp : MonoBehaviour
{
    public List<Vector3> directions;
    public List<int> sideValues;

    void Awake()
    {
        // For the sake of this example we assume a regular cube dice if 
        // directions haven't been specified in the editor. Sum of opposite
        // sides is 7, haven't consider exact real layout though.
        if (directions.Count == 0)
        {
            // Object space directions
            directions.Add(Vector3.up);
            sideValues.Add(1); // up
            directions.Add(Vector3.down);
            sideValues.Add(6); // down

            directions.Add(Vector3.left);
            sideValues.Add(3); // left
            directions.Add(Vector3.right);
            sideValues.Add(4); // right

            directions.Add(Vector3.forward);
            sideValues.Add(2); // fw
            directions.Add(Vector3.back);
            sideValues.Add(5); // back
        }

        // Assert equal side of lists
        if (directions.Count != sideValues.Count)
        {
            Debug.LogError("Not consistent list sizes");
        }
    }

    void Start()
    {
        // For sake of example, get number based on current orientation
        // This makes it possible to test by just rotating it in the editor and hitting play
        // Allowing 30 degrees error so will give (the side that is mostly upwards)
        // but will give -1 on "tie"
        Debug.Log("The side world up has value: " + GetNumber(Vector3.up, 30f));
    }

    public int DiceValue_Up;
    public int DiceValue_Front;

    public float x, y, z;
    void Update()
    {
        DiceValue_Up = GetNumber(Vector3.up, 30f);
        DiceValue_Front = GetNumber(Vector3.forward, 30f);
        x = transform.localRotation.eulerAngles.x;
        y = transform.localRotation.eulerAngles.y;
        z = transform.localRotation.eulerAngles.z;
    }

    // Gets the number of the side pointing in the same direction as the reference vector,
    // allowing epsilon degrees error.
    public int GetNumber(Vector3 referenceVectorUp, float epsilonDeg = 5f)
    {
        // here I would assert lookup is not empty, epsilon is positive and larger than smallest possible float etc
        // Transform reference up to object space
        Vector3 referenceObjectSpace = transform.InverseTransformDirection(referenceVectorUp);

        // Find smallest difference to object space direction
        float min = float.MaxValue;
        int mostSimilarDirectionIndex = -1;
        for (int i = 0; i < directions.Count; ++i)
        {
            float a = Vector3.Angle(referenceObjectSpace, directions[i]);
            if (a <= epsilonDeg && a < min)
            {
                min = a;
                mostSimilarDirectionIndex = i;
            }
        }

        // -1 as error code for not within bounds
        return (mostSimilarDirectionIndex >= 0) ? sideValues[mostSimilarDirectionIndex] : -1;
    }
}
