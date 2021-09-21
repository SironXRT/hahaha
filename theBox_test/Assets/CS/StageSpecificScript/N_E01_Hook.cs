using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_E01_Hook : MonoBehaviour
{
    public int Score = 0;
    List<GameObject> Fishes;
    public Transform FishPound;
    void Start()
    {
        Fishes = new List<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fish")
        {
            Score += col.GetComponent<N_E01_Fish>().Score;
            col.GetComponent<N_E01_Fish>().enabled = false;
            col.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            col.GetComponent<BoxCollider2D>().enabled = false;
            col.gameObject.transform.SetParent(this.transform);
            Fishes.Add(col.gameObject);
        }
    }

    public void ClearScore()
    {
        Score = 0;
        for (int i = 0; i < Fishes.Count; i++)
        {
            Fishes[i].SetActive(false);
            Fishes[i].GetComponent<N_E01_Fish>().enabled = true;
            Fishes[i].GetComponent<BoxCollider2D>().enabled = true;
            Fishes[i].transform.SetParent(FishPound);

            Fishes[i].SetActive(true);
        }

        Fishes.Clear();
    }
}
