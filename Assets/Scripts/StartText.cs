using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
  public float görüntülenmeSüresi = 4.0f; 
  private Text startText;

  void Start()
  {
   
    startText = GameObject.FindGameObjectWithTag("StartText").GetComponent<Text>();
    startText.gameObject.SetActive(true);

    
    Invoke("StartTextKapanma", görüntülenmeSüresi);
  }

  void StartTextKapanma()
  {
    startText.gameObject.SetActive(false);
  }
}
