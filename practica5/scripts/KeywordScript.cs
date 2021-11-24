using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class KeywordScript : MonoBehaviour
{
    [SerializeField]
    private Button boton;
    public static bool activo= false;

    public string[] m_Keywords = new String[] {"arriba","izquierda","derecha"};
    public GameObject cubo;

    private KeywordRecognizer m_Recognizer;
    private bool stop = true;
    public Text texto;

    void Start()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(TaskOnClick);
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
    }
    
    void Update() {
        if(m_Recognizer.IsRunning){
          if(stop) {
            m_Recognizer.Stop();
            Debug.Log("Desactivado");
            activo = false;
            PhraseRecognitionSystem.Shutdown();
          }
        }else{
          if(!stop) {
            PhraseRecognitionSystem.Restart();
            m_Recognizer.Start();
            activo = true;
            Debug.Log("activo");
          }   
        }
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        switch (args.text)
        {
            case "arriba": 
              cubo.transform.position = new Vector3(cubo.transform.position.x,cubo.transform.position.y+1,cubo.transform.position.z);
              texto.text = "Comando: arriba";
            break;
            
            case "izquierda": 
              cubo.transform.position = new Vector3(cubo.transform.position.x -1,cubo.transform.position.y,cubo.transform.position.z);
              texto.text = "Comando: izquierda";
            break;
            
            case "derecha": 
              cubo.transform.position = new Vector3(cubo.transform.position.x +1,cubo.transform.position.y,cubo.transform.position.z);
              texto.text = "Comando: derecha";
            break;
            default:
             break;
        }
       
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
    }

    void TaskOnClick(){
       if (!DictationScript.activo){
        stop = !stop;
       }else {
        Debug.Log("Desactive el dictado por voz");
       }
    }

    void OnDestroy(){
      m_Recognizer.Dispose();
    }
}