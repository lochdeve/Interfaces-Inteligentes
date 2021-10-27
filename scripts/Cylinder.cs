using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    // Start is called before the first frame update
       GameObject character;
       GameObject sphere;

        private Vector3 startingScale;

  
  
    void Start()
    {
        startingScale = transform.localScale;
       character = GameObject.FindWithTag("character");
       sphere = GameObject.FindWithTag("sphere");
    }

    // Update is called once per frame
    void Update()
    { 

     int characterDistance =(int) Vector3.Distance (character.transform.position, transform.localPosition);
     int sphereDistance = (int)Vector3.Distance (sphere.transform.position, transform.localPosition);

   
        transform.localScale = startingScale / sphereDistance;
        transform.localScale *= characterDistance;

      
    }

}
