using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipo1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter(Collision collision){
      GameObject character = GameObject.Find("character");
      if (collision.gameObject.tag == "character")
      {
      transform.localScale = new Vector3(transform.localScale.x +1,transform.localScale.y +1, transform.localScale.z +1);
      }
      Debug.Log("colisiono");
      
    }
}
