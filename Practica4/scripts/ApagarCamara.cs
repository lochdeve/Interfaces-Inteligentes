using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApagarCamara : MonoBehaviour
{
    WebCamTexture webcamTexture;
    // Start is called before the first frame update
    private camera script;
   
    void Start()
    {
        Button boton = GetComponent<Button>();
		boton.onClick.AddListener(TaskOnClick);
        script= FindObjectOfType<camera>();
        Renderer renderer = GetComponent<Renderer>();
    }

   
     void TaskOnClick(){
        webcamTexture = script.webcamTexture;
      webcamTexture.Stop();
	}   
}
