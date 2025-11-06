using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScene : MonoBehaviour
{
  public TMP_Text geçenZamanText;
  void Start()
  {
    Debug.Log("WinScene başlatıldı.");
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    float geçenZaman = PlayerPrefs.GetFloat("GeçenZaman", 0);
    int minutes = Mathf.FloorToInt(geçenZaman / 60F);
    int seconds = Mathf.FloorToInt(geçenZaman % 60F);
    string yazilacakTime = string.Format("{0:0}:{1:00}", minutes, seconds);
    
   geçenZamanText.text = "Time: " + yazilacakTime;
  }

  public void MainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }

}


