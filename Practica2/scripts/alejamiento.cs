using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alejamiento : MonoBehaviour
{
    GameObject character;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindWithTag("character");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     int characterDistance =(int) Vector3.Distance (character.transform.position, transform.localPosition);
        
        if(characterDistance <= 5) {
            //transform.position = new Vector3(transform.position.x + 1, 0, 0);
            rb.AddForce(transform.position);
        }
    }
}