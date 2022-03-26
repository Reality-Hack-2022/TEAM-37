using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InputMgr : MonoBehaviour
{
    public GameObject volumeSlider;
    public GameObject playThroughSwitch;
    public GameObject tutorialPanel;
    public GameObject mainMenuPanel;
    private void Update()
    {
        //IN THE MAIN MENU
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ProgressionMgr.instance.volumetricPlayer.CurStep = -1;
            ProgressionMgr.instance.volumetricPlayer.gameObject.SetActive(true);
            StartTutorial();
        }   
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ProgressionMgr.instance.volumetricPlayer.CurStep = 0;
            ProgressionMgr.instance.volumetricPlayer.gameObject.SetActive(true);
            StartTutorial();
        }



        //WHEN THE VOLUMETRIC PLAYER IS RUNNING
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextTutorialElement();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousTutorialElement();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TogglePaused();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ExitTutorial();
        }
    }

    public void ToggleVolumeSlider()
    {
        Debug.Log("Toggle Volume ");
        volumeSlider.SetActive(volumeSlider.activeSelf);
    }
    public void SetVolume()
    {
        Debug.Log($"Set volume to {volumeSlider.GetComponent<Slider>().value}");

        if (!ProgressionMgr.instance.volumetricPlayer) return;
        //ProgressionMgr.instance.volumetricPlayer.SetVolume(volumeSlider.GetComponent<Slider>().value);
    }

    public void SetPlaySpeed()
    {
        Debug.Log("Setting playbackspeed 0.5");

        if (!ProgressionMgr.instance.volumetricPlayer) return;
        ProgressionMgr.instance.volumetricPlayer.PlaybackSpeed = 0.5f; 
    }

    public void NextTutorialElement()
    {
        if (!ProgressionMgr.instance.volumetricPlayer) return;
        ProgressionMgr.instance.volumetricPlayer.CurStep++;
        ProgressionMgr.instance.SetUIElement();
    }
    public void PreviousTutorialElement()
    { 
        if (!ProgressionMgr.instance.volumetricPlayer) return;
        ProgressionMgr.instance.volumetricPlayer.CurStep--;
        ProgressionMgr.instance.SetUIElement();
    }

    public void TogglePaused()
    {
        Debug.Log("Pause");
        if (!ProgressionMgr.instance.volumetricPlayer) return;
        if (ProgressionMgr.instance.volumetricPlayer.GetPlaybackState() == VolumetricPlayer.PlaybackState.Playing)
        {
            ProgressionMgr.instance.volumetricPlayer.SetPlaybackState(VolumetricPlayer.PlaybackState.Paused);
        }
        if (ProgressionMgr.instance.volumetricPlayer.GetPlaybackState() == VolumetricPlayer.PlaybackState.Paused)
        {
            ProgressionMgr.instance.volumetricPlayer.SetPlaybackState(VolumetricPlayer.PlaybackState.Playing);
        }
    }

    public void Restart()
    {
        if (!ProgressionMgr.instance.volumetricPlayer) return;
        //ProgressionMgr.instance.volumetricPlayer.SetStep(0);
        Debug.Log("Restart");

    }

    public void StartTutorial()
    {
        ProgressionMgr.instance.StartTutorial();
        Debug.Log("Start");

    }
    public void ExitTutorial()
    {
        if (!ProgressionMgr.instance.volumetricPlayer) return;

        Debug.Log("Exit");
    }



    public void TogglePlaythrough()
    {
        if (!ProgressionMgr.instance.volumetricPlayer) return;
        Debug.Log("Toggle Playthrough");
    }





}
