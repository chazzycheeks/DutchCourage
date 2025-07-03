using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string id;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;

}
public class AudioManager : MonoBehaviour
{
    public List<Sound> soundList;
    public MusicManager musicManager;

    private void Start()
    {
        StartCoroutine(DelayMusicStart());
    }


    public void PlayCannon()
    {
        PlaySound("cannon");
    }
    public void PlayGlug()
    {
        PlaySound("glug");
    }
    public void PlayAlert()
    {
        PlaySound("alert");
    }
    public void PlaySplash()
    {
        PlaySound("splash");
    }
    public void PlaySwig()
    {
        PlaySound("swig");
    }
    public void PlayMove()
    {
        PlaySound("move");
    }
    public void PlayAwaken()
    {
        PlaySound("awaken");
    }
    public void PlayHighYaar()
    {
        PlaySound("yaarhigh");
    }
    public void PlayMidYaar()
    {
        PlaySound("yaarmid");
    }
    public void PlayLowYaar()
    {
        PlaySound("yaarlow");
    }
    public void PlayDrunkYaar()
    {
        PlaySound("yaardrunk");
    }
    public void PlayLowCourageAlert()
    {
        PlaySound("lowcourage");
    }
    public void PlayPunch()
    {
        PlaySound("punch");
    }
    public void PlayEnemyHit()
    {
        PlaySound("enemyhit");
    }
    public void PlayPlayerHit()
    {
        PlaySound("playerhit");
    }
    public void PlaySink()
    {
        PlaySound("sink");
    }
    private void PlaySound(string targetId)
    {

        //Local variable which stores the audiosource we're going to play on
        //go through the list of audio sources (for or foreach loop)
        //Once you have found one that isn't playing - play on that one

        AudioSource audioSource = GetComponent<AudioSource>();

        Sound soundToPlay = FindSoundWithId(targetId, audioSource);

        if (soundToPlay == null)
        {
            return;
        }

        audioSource.PlayOneShot(soundToPlay.clip, soundToPlay.volume);

        return;
    }

    private Sound FindSoundWithId(string targetId, AudioSource source)
    {
        foreach (Sound sound in soundList)
        {
            if (sound.id != targetId)
            {
                continue;
            }

            return sound;
        }

        return null;
    }
    private IEnumerator DelayMusicStart()
    {
        musicManager.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        musicManager.gameObject.SetActive(true);
    }
}

