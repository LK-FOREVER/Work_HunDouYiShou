using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
 
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Rotate(0, 0, 100f * Time.deltaTime);
    }
}
