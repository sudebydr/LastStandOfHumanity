using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AtesEtme : MonoBehaviour
{
  RaycastHit hit;
  public GameObject uzaklik;
  public GameObject TabancaninUci;
  public float AtesHizi;
  public bool AtesEdebilir;
  float GunTimer;
  AudioSource SesKaynak;
  public AudioClip SilahSes;
  public float Menzil;
  public ParticleSystem MuzzleFlash;
  public SilahGeriTepme geriTepme;
  
  public float mermi;
  float eklenenMermi;
  public float maxMermi;
  float reloadTimer;
  public float hasar;

  public TMP_Text mermiSayac;
  public Image Crosshair;
    void Start()
    {
    SesKaynak = GetComponent<AudioSource>();
    }

    
    void Update()
    {

    if (Physics.Raycast(uzaklik.transform.position, uzaklik.transform.forward, out hit, 2f))
    {
      if (hit.transform.tag == "mermiKutusu")
      {
        Crosshair.color = Color.red;

        if (Input.GetKeyDown(KeyCode.E))
        {
          Destroy(hit.transform.gameObject);
          mermi += 10;

          if (mermi > 100)
          {
            mermi = 100;
          }
        }
      }
      else
      {
        Crosshair.color = Color.green;
      }
    }


    mermiSayac.text = "Bullet:" + "" + mermi + "/" + maxMermi;
    
    if(maxMermi<eklenenMermi)
    {
      eklenenMermi = maxMermi;
    }

    if(Input.GetKeyDown(KeyCode.R)&& eklenenMermi>0&&maxMermi>0)
    
      if (Time.time > reloadTimer)
      {
        StartCoroutine(Reload());
      }
    

    if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir == true && Time.time > GunTimer && mermi > 0) 
     {
      Fire();
      GunTimer = Time.time + AtesHizi;
      geriTepme.Fire();
      
      
    }

    }
  void Fire()
  {
    if(mermi<=0)
    {
      AtesEdebilir = false;
    }
    if(mermi>0)
    {
      AtesEdebilir = true;
      mermi--;
    }
    if(Physics.Raycast(TabancaninUci.transform.position,TabancaninUci.transform.forward, out hit, Menzil))
    {
      MuzzleFlash.Play();
      SesKaynak.Play();
      SesKaynak.clip = SilahSes;
      Debug.Log(hit.transform.name);

      if(hit.transform.tag=="Enemy")
      {
        EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
        enemyHealthScript.healthKesinti(hasar);

      }
      else
      {
        Debug.Log("Iskaladin");
      }

    }
  }
  IEnumerator Reload()
  {
    yield return new WaitForSeconds(1.2f);
    mermi = mermi + eklenenMermi;
    maxMermi = maxMermi - eklenenMermi;
  }
}
