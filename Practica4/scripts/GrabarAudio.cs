using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabarAudio : MonoBehaviour
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
        Debug.Log("Grabando Audio");
        grabacion.clip = Microphone.Start("Auriculares con micrófono (JBL LIVE500BT Hands-Free AG Audio)", false, 2, 44100);
	}
}
