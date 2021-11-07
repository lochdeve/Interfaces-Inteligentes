using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class encenderCamara : MonoBehaviour
{
    public GameObject camara;
    WebCamTexture webcamTexture;
    // Start is called before the first frame update
    public Button botonPublico;
    private camera script;
   
    void Start()
    {
        Button boton = botonPublico.GetComponent<Button>();
		boton.onClick.AddListener(TaskOnClick);
        script= FindObjectOfType<camera>();
        Renderer renderer = GetComponent<Renderer>();
    }

   
     void TaskOnClick(){
        webcamTexture = script.webcamTexture;
      webcamTexture.Play();
	}
}
