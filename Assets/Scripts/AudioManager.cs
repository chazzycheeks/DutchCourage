using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Sound
{
    public string id;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;

}
public class AudioManager : MonoBehaviour
{
    public List<Sound> soundList;
    public List<AudioSource> audioSources;
    public MusicManager musicManager;

    private void Start()
    {
        StartCoroutine(DelayMusicStart());
    }


    /* public void PlayDoorbell()
     {
         PlaySound("DoorRing");
     }*/


    private void PlaySound(string targetId)
    {

        //Local variable which stores the audiosource we're going to play on
        //go through the list of audio sources (for or foreach loop)
        //Once you have found one that isn't playing - play on that one
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying == false)
            {
                /*audioSource.clip = null;*/

                FindSoundWithId(targetId, audioSource);

                if (audioSource.clip == null)
                {
                    return;
                }

                audioSource.Play();

                return;
            }

        }

    }
    private void FindSoundWithId(string targetId, AudioSource source)
    {
        foreach (Sound sound in soundList)
        {
            if (sound.id != targetId)
            {
                continue;
            }

            source.clip = sound.clip;
            source.volume = sound.volume;
            break;
        }
    }
    private IEnumerator DelayMusicStart()
    {
        musicManager.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        musicManager.gameObject.SetActive(true);
    }
}

