using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject square;
    public Text timeTxt;
    public static GameManager Instance;
    public Text nowScore;
    public GameObject endPanel;
    public Text bestScore;

    bool isPlay = true;


    float time = 0f;
    // Start is called before the first frame update
    public Animator anim;

   
    string key = "bestScore";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
    }

        void Start()
        {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare", 0.0f, 1f);
        }

        // Update is called once per frame
        void Update()
        {
    if (isPlay)
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }
}
        void MakeSquare()
        {
            Instantiate(square);
        }

    public void GameOver()
    {

        isPlay= false;
        anim.SetBool("isDie", true);
        Invoke("TimeStop", 0.5f);
        nowScore.text = time.ToString("N2");

        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if (best < time)
            {
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            else
            {
                bestScore.text = best.ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }

        endPanel.SetActive(true);
    }
    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }

}


