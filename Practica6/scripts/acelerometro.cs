using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class acelerometro : MonoBehaviour
{
    public Text vidasTexto;
    private Rigidbody rb;
    private float velocidad = 2;
    private int vidasRestantes = 5; 
    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 inclinacion = Input.acceleration;
        
        inclinacion =   Quaternion.Euler(90,0,0)* inclinacion;

        rb.AddForce(inclinacion* velocidad);
    }

     void OnCollisionEnter(Collision collision){
       if (collision.gameObject.tag == "obstaculo" && vidasRestantes <= 0){
         vidasRestantes = 5;
         transform.position = posicionInicial;
         vidasTexto.text = "Vidas: 5\nHas perdido";
       }else if (collision.gameObject.tag == "obstaculo"){
         vidasRestantes--;
         vidasTexto.text = "Vidas: " + vidasRestantes;
       } else if (collision.gameObject.tag == "Final" && vidasRestantes > 0){
         vidasTexto.text = "Has ganado";
         transform.position = posicionInicial;
         vidasRestantes = 5;
       }else if (collision.gameObject.tag == "Final" && vidasRestantes <= 0){
         vidasRestantes = 5;
         transform.position = posicionInicial;
         vidasTexto.text = "Vidas: 5\nHas perdido";
       }  
    }
}
