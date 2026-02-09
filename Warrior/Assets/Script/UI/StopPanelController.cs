using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopPanelController : MonoBehaviour
{
    public Button closeBtn;
    public Button continueBtn;
    public Button exitBtn;
    public PlayerScript p;
    public GameObject mainPanel;

    void Start()
    {
        closeBtn.onClick.AddListener(OnClickContinueBtn);
        continueBtn.onClick.AddListener(OnClickContinueBtn);
        exitBtn.onClick.AddListener(OnClickExitBtn);
    }
    public void OnClickContinueBtn()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnClickExitBtn()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        gameObject.SetActive(false);
        SceneManager.LoadScene("StartScene");
        EventManager.Instance.TriggerEvent(EventName.ChangeMusic, this, new ChangeMusicArgs { index_music = 0 });
        EventManager.Instance.TriggerEvent(EventName.ResetPlayerState, this);
        mainPanel.SetActive(true);
        ObjectPoolManager.Instance.Clear();
        Time.timeScale = 1.0f;
    }
}
