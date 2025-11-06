using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
  private int oldurulenEnemy = 0;
  private int maxEnemies = 12;
  private float startTime;

  private void Start()
  {
   startTime = Time.time;
  }


  public void EnemyKilled()
  {
    
    oldurulenEnemy++;
    if (oldurulenEnemy >= maxEnemies)
    {
      WinGame();
    }
  }

  private void WinGame()
  {
    float geçenZaman = Time.time - startTime;
    PlayerPrefs.SetFloat("GeçenZaman", geçenZaman);
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    SceneManager.LoadScene("WinScene");
    
  }
}



