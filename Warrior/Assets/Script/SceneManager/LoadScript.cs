using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour
{
   

    public Image load;

    AsyncOperation async;

    float Realloadvalue = 0;

    float loadvalue = 0;


    public Text showload;

    //public VideoPlayer v;

    
    void Start()
    {
       
        StartCoroutine("AsyncLoadScene");
        //Invoke("falseWarning", 3f);
        //v = GetComponent<VideoPlayer>();
        //v.Play();
    }
    void Update()
    {
        if (async == null)                                //Ԥ��
        {
            return;
        }
       
        if (async.progress < 0.9f)
        {
            Realloadvalue = (int)(async.progress * 100);
        }
        else
        {
            Realloadvalue = 100;
        }
        if (loadvalue <= Realloadvalue)
        {
            loadvalue += 1f;
            /*showload.text = ((int)loadvalue).ToString() + "%";*/
            load.fillAmount = loadvalue / 100.0f;
        }
        if (loadvalue >= 100)
        {
           
            async.allowSceneActivation = true;
           
        }
    }
    IEnumerator AsyncLoadScene()
    {
        yield return new WaitForSeconds(0.1f);
        async = SceneManager.LoadSceneAsync("GameScene");
        async.allowSceneActivation = false;
        yield return async;
    }
   
}
