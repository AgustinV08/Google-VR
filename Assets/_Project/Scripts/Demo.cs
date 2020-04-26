using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public void red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }    
    
    public void blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
    
    public void black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
