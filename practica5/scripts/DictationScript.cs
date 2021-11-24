using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System;


public class DictationScript : MonoBehaviour
{
    [SerializeField]
    private Text m_Hypotheses;
    private Button boton;

    private string uiText;

    [SerializeField]
    private Text m_Recognitions;
    private bool stop = false;
    public static bool activo = false;


    private DictationRecognizer m_DictationRecognizer;

    public Text texto;
    void Start()
    {
      boton = GetComponent<Button>();
      boton.onClick.AddListener(TaskOnClick);
      m_DictationRecognizer = new DictationRecognizer();

      m_DictationRecognizer.DictationResult += dictationResult;
         
     // m_DictationRecognizer.DictationHypothesis += dictationHypothesis;

      m_DictationRecognizer.DictationComplete += dictationComplete;

      //m_DictationRecognizer.Start();
    }

   private void dictationComplete(DictationCompletionCause completionCause){
      if (completionCause != DictationCompletionCause.Complete)
        Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
   }

    /*private void dictationHypothesis(string text){
      //Debug.LogFormat("Dictation hypothesis: {0}", text);
      m_Hypotheses.text += text;
    }*/


      void dictationResult(string text, ConfidenceLevel confidence){
        Debug.LogFormat("Dictation result: {0}", text);
        Debug.LogFormat( text);
      //m_Recognitions.text += text + "\n";
      uiText = text;
        texto.text = uiText;
    }

    void TaskOnClick(){
      if(!KeywordScript.activo) {

      if(stop){
        m_DictationRecognizer.Stop();
        Debug.Log("DESATIVADO");
        activo = false;
        stop = !stop;
      }else {
        m_DictationRecognizer.Start();
        Debug.Log("activo");
        activo = true;
        stop = !stop;
      }
      }else {
        Debug.Log("Desactive el KEyword primero");
      }
    }

    void OnDestroy(){
      m_DictationRecognizer.Dispose();
    }

}