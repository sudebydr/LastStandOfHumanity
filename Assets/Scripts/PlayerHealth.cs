using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  public float playerHealth = 100f;
  public TMP_Text Health;
  public Slider healthBar;
  RaycastHit hit;
  public GameObject uzaklik;
  public Image Crosshair;



  void Update()
  {
    Health.text = "Health:"+"" + playerHealth + "/" + "100";
    healthBar.value = playerHealth / 100f;

    if (Physics.Raycast(uzaklik.transform.position, uzaklik.transform.forward, out hit, 2f))
      if(hit.transform.tag=="healthpack")
      {
        Crosshair.color = Color.red;

        if (Input.GetKeyDown(KeyCode.E))
        {
          Destroy(hit.transform.gameObject);
          playerHealth += 30;

          if(playerHealth>100)
          {
            playerHealth = 100;
          }
        }
      }
      else
      {
        Crosshair.color = Color.green;
      }

  }

  public void VerilenHasar (float verilenHasar)
  {
    playerHealth -= verilenHasar;
    if (playerHealth <= 0)
    {
      PlayerDead();
    }


    void PlayerDead()
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      SceneManager.LoadScene("GameOverScene");

      

    }

  }

}
