using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamCon : MonoBehaviour
{
    public int score;
    private int wave;


    public GameObject sound_pic;
    public GameObject toturial_pic;
    

    public Text score_text;
    public Text wave_text;

    public bool isMute;

    public GameObject EndUI;
    public GameObject PauseUI;
    public bool isPause;
    public Animator anime_, panel_anime;
    public bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isMute = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toturial_pic.SetActive(false);
        }



        

        sound_pic.SetActive(isMute);

        this.GetComponent<AudioListener>().enabled = isMute;


        wave = this.GetComponent<SpawnMon>().wave;

        score_text.text = "score : " + score.ToString();
        wave_text.text = "wave : " + wave.ToString();


        if (!isStart)
        {
            Time.timeScale = 0f;
        }
        if (isStart)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = !isPause;

            }
 
            if (isPause)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(Wait_reset());

                }
                Time.timeScale = 0f;
                PauseUI.SetActive(true);

            }
            if (!isPause)
            {
                Time.timeScale = 1f;
                PauseUI.SetActive(false);

            }

            if(GameObject.FindGameObjectWithTag("Pet").GetComponent<Pet>().health <= 0)
            {
                StartCoroutine(wait_ded());
                if (Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(Wait_reset());

                }

            }
        }

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;
    }

    public void Click_Start()
    {
        FindObjectOfType<SoundManager>().Play("Click");

        isStart = true;
    }

    IEnumerator Wait_reset()
    {
        panel_anime.SetTrigger("end");
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator wait_ded()
    {
        yield return new WaitForSeconds(1.5f);
        EndUI.SetActive(true);
    }


    public void mute()
    {
        isMute = !isMute;
    }


    public void Toturial()
    {
        toturial_pic.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
