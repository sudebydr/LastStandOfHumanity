using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
  public float enemyHealth = 100f;
  private Animator enemyAimator;
  private Enemy enemy;
  private EnemyCounter enemyCounter;


  void Start()
  {
    enemyAimator = GetComponent<Animator>();
    enemy = GetComponent<Enemy>();
    enemyCounter = FindObjectOfType<EnemyCounter>();
    
  }


  public void healthKesinti(float healthKesinti)
  {
    enemyHealth -= healthKesinti;
    if(enemyHealth==0)
    {
      enemyDead();
    }


    void enemyDead()
    {
      enemy.enabled = false;
      enemyAimator.SetBool("EnemyDead", true);
      Destroy(gameObject,20f);
      

      if (enemyCounter != null)
      {
        enemyCounter.EnemyKilled();
        Debug.Log("enemykilled");
      }

    }

  }

}
