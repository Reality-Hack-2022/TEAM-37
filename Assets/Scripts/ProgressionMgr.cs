using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayPauseInfo
{
    public Sprite pause;
    public Sprite play;
}
public class ProgressionMgr : MonoBehaviour
{
    public static ProgressionMgr instance;

    [Header("Tutorial Objects")]
    public VolumetricPlayer volumetricPlayer;
    public GameObject extraVolumetricPlayers;


    [Header("UI Objects")]
    public GameObject mainMenuPanel;
    public GameObject tutorialPanel;
    public SpriteRenderer playPausePanel;
    public PlayPauseInfo playPause;
    public SpriteRenderer contentPoster;
    public List<Sprite> contentPanels = new List<Sprite>();

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    public void StartTutorial(int startStep = 0)
    {
        Debug.Log($"Starting Tutorial in Progression MGR from step {startStep}");

        volumetricPlayer.CurStep = startStep;
        volumetricPlayer.gameObject.SetActive(true);
        volumetricPlayer.SetPlaybackState(VolumetricPlayer.PlaybackState.Playing);

        extraVolumetricPlayers.SetActive(true);
        mainMenuPanel.SetActive(false);
        tutorialPanel.SetActive(true);

        volumetricPlayer.OnStepChanged.AddListener(SetUIElement);
        volumetricPlayer.OnStepChanged.AddListener(StepChanged);

        volumetricPlayer.CurStep = startStep;
        SetUIElement();
        //Tutorials[whichTutorial].PlayTutorial();
    }

    public void StepChanged(int i = 0)
    {
        Debug.Log("Step Change");

    }
    public void SetUIElement(int i = 0)
    {
        if (contentPanels[i])
            contentPoster.sprite = contentPanels[i];
        Debug.Log($"Try Content Panel Change {i}");
    }

    public void StartContinuous()
    {

    }

    public void TogglePaused()
    {
        Debug.Log("Toggle paused in progression Man");
        if (volumetricPlayer.GetPlaybackState() == VolumetricPlayer.PlaybackState.Playing)
        {
            SetPaused();
        }
        if (volumetricPlayer.GetPlaybackState() == VolumetricPlayer.PlaybackState.Paused)
        {
            SetPlaying();
        }
    }

    public void SetPaused()
    {
        volumetricPlayer.SetPlaybackState(VolumetricPlayer.PlaybackState.Paused);
        playPausePanel.sprite = playPause.pause;
    }

    public void SetPlaying()
    {
        volumetricPlayer.SetPlaybackState(VolumetricPlayer.PlaybackState.Playing);
        playPausePanel.sprite = playPause.play;
    }





}
