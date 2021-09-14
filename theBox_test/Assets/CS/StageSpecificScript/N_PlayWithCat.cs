using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class N_PlayWithCat : MonoBehaviour
{
    Arduino arduino;

    public Image Bubble;
    public Text txt;
    public string[] Strings;
    public float popupTime;
    public float AwaitTime;
    public float NextCoversationTime;
    public bool floating = false;

    public Image BK_Trans;
    public Image Trans_Red;
    public Image fur1, fur2, fur3;

    bool furniture_Explode = false;
    bool furniture_SuperBANANA = false;
    bool Warningout = false;
    bool game_explode = false;

    public Text Warn_txt;
    public Text txt_Knob;
    public GameObject pic1, pic2;
    public AudioClip[] ac;
    public AudioSource As;


    bool music_Changing = false;
    int current_music = 0;

    public Image bg;
    public Sprite[] backgrounds;

    bool SongOut = false;
    // Button knob 0 ~ 1024 > 10 ~ 1010
    // Start is called before the first frame update
    void Start()
    {
        arduino = GameObject.FindGameObjectWithTag("Cube").GetComponent<Arduino>();
    }

    // Update is called once per frame
    void Update()
    {
        int ar = arduino.Button_Knob / 100;
        txt_Knob.text = ar.ToString();

        if (arduino.Switch_State == 1)
        {
            fur1.gameObject.SetActive(true);
            fur2.gameObject.SetActive(true);
            fur3.gameObject.SetActive(true);
        }
        else if (!furniture_SuperBANANA)
        {
            fur1.gameObject.SetActive(false);
            fur2.gameObject.SetActive(false);
            fur3.gameObject.SetActive(false);
        }

        if (!SongOut)
        {
            CheckMusic();
        }

        if (arduino.Button_Knob <= 200)
        {
            BK_Trans.color = new Color(BK_Trans.color.r, BK_Trans.color.g, BK_Trans.color.b, Mathf.Abs(((arduino.Button_Knob - 10f) / 190f) - 1));
        }
        else if (arduino.Button_Knob <= 800)
        {

        }
        else if (arduino.Button_Knob <= 950)
        {
            Trans_Red.color = new Color(1, 0, 0, (arduino.Button_Knob - 800f) / 150f <= 0 ? 0 : (arduino.Button_Knob - 800f) / 150f);
        }

        if (arduino.Button_Knob >= 550 && !Warningout)
        {
            Warningout = true;
            Warn_txt.gameObject.SetActive(true);
        }
        if (arduino.Button_Knob >= 500 && !furniture_SuperBANANA)
        {
            furniture_SuperBANANA = true;
            fur1.gameObject.SetActive(true);
            fur2.gameObject.SetActive(true);
            fur3.gameObject.SetActive(true);

            fur1.GetComponent<SuperBanana>().Active();
            fur2.GetComponent<SuperBanana>().Active();
            fur3.GetComponent<SuperBanana>().Active();
        }
        if (arduino.Button_Knob >= 700 && !furniture_Explode)
        {
            furniture_Explode = true;


            fur1.sprite = null;
            fur2.sprite = null;
            fur3.sprite = null;

            fur1.GetComponent<SuperBanana>().Deactivate();
            fur2.GetComponent<SuperBanana>().Deactivate();
            fur3.GetComponent<SuperBanana>().Deactivate();

            fur1.color = new Color(1, 1, 1, 1);
            fur2.color = new Color(1, 1, 1, 1);
            fur3.color = new Color(1, 1, 1, 1);
        }
        if (arduino.Button_Knob >= 990 && !game_explode)
        {
            game_explode = true;
            StartCoroutine(Exploded());
        }


        if (arduino.Button_Press == 0 && !floating)
        {
            StartCoroutine(ShowCode());
            floating = true;
        }
    }

    void CheckMusic()
    {
        int a = arduino.Button_Knob;
        if (a <= 99 && current_music != 0)
        {
            bg.sprite = backgrounds[0];
            current_music = 0;
            StopCoroutine(ChangeSong());
            StartCoroutine(ChangeSong());
            return;
        }

        if (a >= 100 && a <= 199 && current_music != 1)
        {
            bg.sprite = backgrounds[1];
            current_music = 1;
            StopCoroutine(ChangeSong());
            StartCoroutine(ChangeSong());
            return;
        }

        if (a >= 200 && a <= 299 && current_music != 2)
        {
            bg.sprite = backgrounds[2];
            current_music = 2;
            StopCoroutine(ChangeSong());
            StartCoroutine(ChangeSong());
            return;
        }

        if (a >= 300 && a <= 399 && current_music != 3)
        {
            bg.sprite = backgrounds[3];
            current_music = 3;
            StopCoroutine(ChangeSong());
            StartCoroutine(ChangeSong());
            return;
        }

        if (a >= 400 && current_music != 4)
        {
            bg.gameObject.SetActive(false);
            As.volume = 1f;
            current_music = 4;
            As.Stop();
            As.PlayOneShot(ac[current_music]);
            //StartCoroutine(ChangeSong());
            SongOut = true;
            return;
        }
    }

    IEnumerator ChangeSong()
    {
        while(As.pitch > 0.1f)
        {
            As.pitch *= 0.92f;
            yield return new WaitForFixedUpdate();
        }

        As.Stop();

        As.PlayOneShot(ac[current_music]);

        while (As.pitch < 1)
        {
            As.pitch *= 1.08f;
            yield return new WaitForFixedUpdate();
        }

        As.pitch = 1;
    }
    IEnumerator Exploded()
    {
        pic1.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.3f);
        pic2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ShowCode()
    {
        Bubble.color = new Color(1, 1, 1, 0);
        txt.text = "";
        while (Bubble.color.a < 1)
        {
            Bubble.color = new Color(Bubble.color.r, Bubble.color.g, Bubble.color.b, Bubble.color.a + Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        int r = Random.Range(0, Strings.Length);

        foreach (char letter in Strings[r].ToCharArray())
        {
            txt.text += letter;

            yield return new WaitForSeconds(AwaitTime);
        }

        yield return new WaitForSeconds(NextCoversationTime);
        floating = false;
    }
}
