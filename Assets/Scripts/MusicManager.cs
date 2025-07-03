using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> musicSources = new List<AudioSource>();
    public DutchCourageMeter DutchCourageMeter;
    public PauseMenu PauseMenu;

    
    private void Update()
    {
        SwitchingTracks();
        if (PauseMenu.isPaused == true)
        {
            foreach (AudioSource musicSource in musicSources)
            {
                musicSource.Pause();
            }
           
        }
        else if (PauseMenu.isPaused == false)
        {
            foreach (AudioSource musicSource in musicSources)
            {
                musicSource.UnPause();
            }
        }
        
    }

    private void SwitchingTracks()
    {
        if (DutchCourageMeter.currentCourage <= 10)
        {
            musicSources[0].mute = false;
            musicSources[1].mute = true;
            musicSources[2].mute = true;
            musicSources[3].mute = true;
        }
        else if (DutchCourageMeter.currentCourage <= 20)
        {
            musicSources[0].mute = true;
            musicSources[1].mute = false;
            musicSources[2].mute = true;
            musicSources[3].mute = true;
        }
        else if (DutchCourageMeter.currentCourage <= 29)
        {
            musicSources[0].mute = true;
            musicSources[1].mute = true;
            musicSources[2].mute = false;
            musicSources[3].mute = true;
        }
        else if (DutchCourageMeter.currentCourage > 29)
        {
            musicSources[0].mute = true;
            musicSources[1].mute = true;
            musicSources[2].mute = true;
            musicSources[3].mute = false;
        }
    }

    
}
