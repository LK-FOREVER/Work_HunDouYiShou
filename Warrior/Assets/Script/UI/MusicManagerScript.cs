using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManagerScript : MonoBehaviour
{

    public Slider musicSlider;
    public Slider soundSlider;
    public CanvasScript c;
    public PlayerScript p;
    public GameObject musicPanel;

    public Button exitGameBtn;
    public Button changeAccountBtn;

    void Start()
    {
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat(SdkScript.nickname + "Music", 0.5f);
        }
        if (soundSlider != null)
        {
            soundSlider.value = PlayerPrefs.GetFloat(SdkScript.nickname + "Sound", 0.5f);
        }
        musicSlider.onValueChanged.AddListener((value) =>
        {
            PlayerPrefs.SetFloat(SdkScript.nickname + "Music", value);
        });
        soundSlider.onValueChanged.AddListener((value) =>
        {
            PlayerPrefs.SetFloat(SdkScript.nickname + "Sound", value);
        });
        exitGameBtn.onClick.AddListener(ExitGame);
        changeAccountBtn.onClick.AddListener(ChangeAccount);
    }

    void Update()
    {
        c.GetComponent<AudioSource>().volume = musicSlider.value;
        p.GetComponent<AudioSource>().volume = soundSlider.value;
        if (p.m != null)
        {
            p.m.GetComponent<AudioSource>().volume = musicSlider.value;
        }
        if(SceneManager.GetActiveScene().name == "LoadStartScene")
        {
            c.GetComponent<AudioSource>().volume = 0;
        }

        // c.GetComponent<AudioSource>().dopplerLevel = soundSlider.value;
        // p.GetComponent<AudioSource>().dopplerLevel = soundSlider.value;
        // if (p.m != null)
        // {
        //     p.m.GetComponent<AudioSource>().dopplerLevel = musicSlider.value;
        // }
    }
    public void ExitGame()
    {
        musicPanel.SetActive(false);
        SceneManager.LoadScene("LoadStartScene");
    }
    public void ChangeAccount()
    {
        musicPanel.SetActive(false);
        SceneManager.LoadScene("LoadStartScene");
    }
}
