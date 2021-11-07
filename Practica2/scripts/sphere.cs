using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
          if (Input.GetKey(KeyCode.L))  
        {  
            transform.Translate(0.01f, 0f, 0f);  
        }  
        if (Input.GetKey(KeyCode.J))  
        {  
            transform.Translate(-0.01f, 0f, 0f);  
        }  
        if (Input.GetKey(KeyCode.M))  
        {  
            transform.Translate(0.0f, 0f, -0.01f);  
        }  
        if (Input.GetKey(KeyCode.I))  
        {  
            transform.Translate(0.0f, 0f, 0.01f);  
        }  
    }
}
