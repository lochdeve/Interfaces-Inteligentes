using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gps : MonoBehaviour
{
    // Start is called before the first frame update
    public Text latitudValue;
    public Text longitudValue;
    public Text altitudValue;
    public Text GpsStatus;
    void Start()
    {
        StartCoroutine(GPS());
    }

    IEnumerator GPS() {

        if (!Input.location.isEnabledByUser){
            yield break;
        }

        Input.location.Start();

        int tiempoMaxDeEspera = 20;

        while ( Input.location.status == LocationServiceStatus.Initializing && tiempoMaxDeEspera > 0)
        {
             yield return new WaitForSeconds(1);
             tiempoMaxDeEspera--;
        }

        if (tiempoMaxDeEspera < 1){
            yield break;
        }
        
        if(Input.location.status == LocationServiceStatus.Failed) {
            GpsStatus.text = "No se puede encontrar localizacion";
            yield  break;
        }else{
            latitudValue.text = "Latitud: " + Input.location.lastData.latitude.ToString();
            longitudValue.text = "Longitud: " + Input.location.lastData.longitude.ToString();
            altitudValue.text = "Altitud: " + Input.location.lastData.altitude.ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
