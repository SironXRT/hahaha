using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MetaGuy : MonoBehaviour
{
    public int Speaker = 1; // 1 = MetaGuy, 2 = Alternative

    public AudioSource adsMeta;
    public AudioClip[] AClips;

    public bool Whispering = false;

    public Text MetaGuyText;

    public string[] MetaGuys;
    public float[] MetaGapTime;
    public float[] MetaAwaitTime;
    public int CurrentMeta = 0;

    public string[] Winquote;
    public float[] WinGapTime;
    public float[] WinAwaitTime;
    public int CurrentWin = 0;

    public void CallSpeak()
    {
        StartCoroutine(MetaGuySpeaks());
    }

    public void CallWinQuotes()
    {
        StopAllCoroutines();
        StartCoroutine(WinQuotes());
    }

    void Start()
    {
        adsMeta = this.GetComponent<AudioSource>();
        CallSpeak();
    }

    IEnumerator MetaGuySpeaks()
    {
        foreach (string s in MetaGuys)
        {
            yield return new WaitForSeconds(MetaAwaitTime[CurrentMeta]);
            MetaGuyText.text = "";

            if (Whispering)
            {
                if (Speaker == 1) adsMeta.PlayOneShot(AClips[0]);
                else adsMeta.PlayOneShot(AClips[1]);
                adsMeta.volume = 1;
                adsMeta.time = Random.Range(0f, 80f);

                foreach (char letter in MetaGuys[CurrentMeta].ToCharArray())
                {
                    MetaGuyText.text += letter;

                    adsMeta.pitch = UnityEngine.Random.Range(0.9f, 1.3f);

                    yield return new WaitForSeconds(MetaGapTime[CurrentMeta]);
                }

                while (adsMeta.volume > 0)
                {
                    adsMeta.volume -= Time.deltaTime;
                    yield return new WaitForFixedUpdate();
                }
                adsMeta.Stop();
            }
            else
            {
                foreach (char letter in MetaGuys[CurrentMeta].ToCharArray())
                {
                    MetaGuyText.text += letter;

                    adsMeta.pitch = UnityEngine.Random.Range(0.9f, 1.3f);

                    if (Speaker == 1) adsMeta.PlayOneShot(AClips[0]);
                    else adsMeta.PlayOneShot(AClips[1]);

                    yield return new WaitForSeconds(MetaGapTime[CurrentMeta]);
                }
            }
            CurrentMeta += 1;
        }
    }

    IEnumerator WinQuotes()
    {
        foreach (string ss in Winquote)
        {
            yield return new WaitForSeconds(WinAwaitTime[CurrentWin]);
            MetaGuyText.text = "";


            if (Whispering)
            {
                if (Speaker == 1) adsMeta.PlayOneShot(AClips[0]);
                else adsMeta.PlayOneShot(AClips[1]);
                adsMeta.volume = 1;
                adsMeta.time = Random.Range(0f, 80f);

                foreach (char letter in ss.ToCharArray())
                {
                    MetaGuyText.text += letter;
                    adsMeta.pitch = UnityEngine.Random.Range(1f, 1.4f);

                    yield return new WaitForSeconds(WinGapTime[CurrentWin]);
                }

                while (adsMeta.volume > 0)
                {
                    adsMeta.volume -= Time.deltaTime;
                    yield return new WaitForFixedUpdate();
                }
                adsMeta.Stop();
            }
            else
            {
                foreach (char letter in ss.ToCharArray())
                {
                    MetaGuyText.text += letter;
                    adsMeta.pitch = UnityEngine.Random.Range(1f, 1.4f);

                    if (Speaker == 1) adsMeta.PlayOneShot(AClips[0]);
                    else adsMeta.PlayOneShot(AClips[1]);

                    yield return new WaitForSeconds(WinGapTime[CurrentWin]);
                }
            }

            CurrentWin += 1;
        }
    }
}
