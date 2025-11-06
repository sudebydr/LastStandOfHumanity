 using UnityEngine;
 using System.Collections;
 
 public class PlayRandomSound : MonoBehaviour {
 
     public AudioSource randomSound;
     public AudioClip[] audioSources;

     public int sesAralıgı = 5;
 
     void Start () {
 
         StartAudio ();
     }
 
 
     void StartAudio()
     {
         Invoke ("RandomSoundness", sesAralıgı);
     }


     void RandomSoundness()
     {
         randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
         randomSound.Play ();
         StartAudio ();
     }
 }