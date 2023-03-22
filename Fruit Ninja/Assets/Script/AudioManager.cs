using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    [SerializeField]private AudioScrptableObject audioClip;
    
    private void Awake() {
        Instance = this;
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector2 position, float volume = 0.3f){
        PlaySound(audioClipArray[Random.Range(0,audioClipArray.Length)],position,volume);
    }
    private void PlaySound(AudioClip audioClip, Vector2 position, float volume = 0.5f){
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
    public void PlayWarningSound(Vector2 position){
        PlaySound(audioClip.warning,position);
    }
    public void PlayChoppingSound(Vector2 position){
        PlaySound(audioClip.chop,position);
    }
    
}
