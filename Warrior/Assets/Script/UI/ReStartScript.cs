using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartScript : MonoBehaviour
{
    public PlayerScript p;
    private ObjectPoolManager poolManager;
    private MapScript mapScript;
    private GameObject m;

    void Awake()
    {

    }
    void Start()
    {
        m = GameObject.Find("MapManager");
        mapScript = m.GetComponent<MapScript>();
        poolManager = ObjectPoolManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReStart()
    {
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        poolManager.Clear();
        mapScript.dic.Clear();
        mapScript.AddBloodList.Clear();
        mapScript.TrapList.Clear();
        mapScript.ObstacleList.Clear();
        mapScript.NpcList.Clear();
        mapScript.NpcArrow.Clear();
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
        //Player.GetComponent<PlayerScript>().IPoints = false;
        //Player.GetComponent<PlayerScript>().ISingle = false;
        //Player.GetComponent<PlayerScript>().IRegame = false;
    }
}
