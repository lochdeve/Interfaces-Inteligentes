using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Button botonPublico;
    public AudioSource grabacion;
    void Start()
    {
        Button boton = botonPublico.GetComponent<Button>();
		boton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        //grabacion = GetComponent<AudioSource>();
        grabacion.clip = Microphone.Start("Auriculares con micrófono (JBL LIVE500BT Hands-Free AG Audio)", false, 2, 44100);
	}
}
