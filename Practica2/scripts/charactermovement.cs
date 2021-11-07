using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class charactermovement : MonoBehaviour
{
     public int score = 0;
     Vector3 Vec;
     public int velocity;
    // Start is called before the first frame update  
    void Start()  
    {  
          
    }  
  
    // Update is called once per frame  
    void Update()  
    {  
        Vec = transform.localPosition;  
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * velocity;  
        Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * velocity;  
        transform.localPosition = Vec; 
    }  

     void OnCollisionEnter(Collision collision){
      GameObject cylinder = GameObject.Find("cylinder");
      if (collision.gameObject.tag == "cylinder")
      {
      score +=1;
      }
      
    }


}
