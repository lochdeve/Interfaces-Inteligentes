
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Brujula : MonoBehaviour {
 
	// Use this for initialization
	void Start () {
        Input.compass.enabled = true;
    }
 
         // Número de llamadas OnGUI
    void OnGUI()
    {
    
    }

    [SerializeField] Image compass;
         float gradoNorte = 0; // Registra el grado norte
         float gradostemporales = 0; // Graba temporalmente datos para juzgar si el cambio de ángulo es mayor que 2
    // Update is called once per frame
    void FixedUpdate () {
                 // Cómo determinar la referencia
                 // Cuando el grado es de 358-2 grados, el teléfono está directamente en frente del norte
 
        Input.location.Start();
               
        gradoNorte = Input.compass.trueHeading;
 
                 // El valor solo se asigna cuando el grado de cambio de fluctuación excede dos
        if (Mathf.Abs(gradostemporales-gradoNorte)>3)
        {
            gradostemporales = gradoNorte;
            compass.transform.eulerAngles = new Vector3(0, 0, gradoNorte);
        }
          
        
    }
}