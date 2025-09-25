using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagerScript : MonoBehaviour
{
   
    public Slider Vslider;
    public Slider Dslider;
    public CanvasScript c;
    public PlayerScript p;
    
    void Start()
    {
        if (Vslider != null)
        {
            Vslider.value = 0.5f;
        }
        if(Dslider != null)
        {
            Dslider.value = 0.5f;
        }   
        
    }

    void Update()
    {   
            c.GetComponent<AudioSource>().volume = Vslider.value;
            p.GetComponent<AudioSource>().volume = Vslider.value;
        if (p.m != null)
        {
            p.m.GetComponent<AudioSource>().volume = Vslider.value;
        }
           
       
      
       
            c.GetComponent<AudioSource>().dopplerLevel = Dslider.value;
            p.GetComponent<AudioSource>().dopplerLevel = Dslider.value;
        if(p.m != null)
        {
            p.m.GetComponent<AudioSource>().dopplerLevel = Vslider.value;
        }
       

    }
}
