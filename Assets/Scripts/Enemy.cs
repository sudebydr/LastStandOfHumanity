using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
  public Transform hedef; 
  public float atesMesafe = 6f; 
  public float takipMesafe = 15f; 
  public float hiz = 3.5f;

  private Animator enemyAnimator;
  private bool isWalking = false;
  private bool isAttacking = false;
  private CharacterController characterController;
  private Vector3 velocity;
  public float gravity = -9.81f; 

  RaycastHit hit;
  public GameObject TabancaninUci;
  public float Menzil;
  public float playerHasar;
  public AudioClip SilahSes;

  AudioSource SesKaynak;

  void Start()
  {
    enemyAnimator = GetComponent<Animator>();
    characterController = GetComponent<CharacterController>();
    SesKaynak = GetComponent<AudioSource>();
  }

  void Update()
  {
    float distanceToTarget = Vector3.Distance(transform.position, hedef.position);

    if (distanceToTarget <= takipMesafe)
    {
      if (distanceToTarget <= atesMesafe && !isAttacking) 
       {
        Attack();
      }
      else if (!isAttacking) 
      {
        Walk();
       }

    }
    else
    {
      StopWalking();
    }

    
    Gravity();
  }

  void Walk()
  {
    if (!isWalking)
    {
      isWalking = true;
      isAttacking = false;
      enemyAnimator.SetBool("isWalking", true);
      enemyAnimator.SetBool("isAttacking", false);
      enemyAnimator.SetFloat("speed", hiz); 
     }

    transform.LookAt(hedef);

    
    RaycastHit hit;
    if (Physics.Raycast(transform.position, transform.forward, out hit, takipMesafe))
    {
      if (hit.collider.tag != "Player")
      {
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, hit.normal, 5f * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
      }
     }

    Vector3 moveDirection = transform.forward * hiz * Time.deltaTime;
    characterController.Move(moveDirection);
  }

  void Attack()
  {

    if (!isAttacking)
    {
      isWalking = false;
      isAttacking = true;
      enemyAnimator.SetBool("isAttacking", true);
      enemyAnimator.SetFloat("speed", 0f); 

      StartCoroutine(PlayGunSoundAndWait());
    }
  }

  IEnumerator PlayGunSoundAndWait()
  {
    if (SesKaynak.isPlaying)
    {
     yield return new WaitUntil(() => !SesKaynak.isPlaying);
    }

    SesKaynak.clip = SilahSes;
    SesKaynak.Play();

    if (Physics.Raycast(TabancaninUci.transform.position, TabancaninUci.transform.forward, out hit, Menzil))
    {
      Debug.Log(hit.transform.name);

      if (hit.transform.tag == "Player")
      {
       PlayerHealth playerHealthScript = hit.transform.GetComponent<PlayerHealth>();
        playerHealthScript.VerilenHasar(playerHasar);
      }
      else
      {
        Debug.Log("Iskaladin");
       }
    }

    yield return new WaitForSeconds(0.1f); 

    isAttacking = false; 

    yield return null;
  }

  void StopWalking()
  {
    if (isWalking || isAttacking)
    {
      isWalking = false;
      isAttacking = false;
      enemyAnimator.SetBool("isWalking", false);
      enemyAnimator.SetBool("isAttacking", false);
      enemyAnimator.SetFloat("speed", 0f); 
    }
  }

  void Gravity()
  {
    if (characterController.isGrounded)
    {
      velocity.y = 0f;
    }
    else
    {
      velocity.y += gravity * Time.deltaTime;
      characterController.Move(velocity * Time.deltaTime);
    }
  }


}

