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

    bool inContinuous => volumetricPlayer.CurStep == -1;
    bool runningTutorial => !mainMenuPanel.activeSelf;


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

    [Header("Visuals")]
    public Spinner discoBall;

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

    
   
    private void Update()
    {
        discoBall.gameObject.SetActive(runningTutorial && inContinuous);
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

        SetPlaying();
        //Tutorials[whichTutorial].PlayTutorial();
    }

    public void ExitTutorial()
    {


        volumetricPlayer.CurStep = 0;
        volumetricPlayer.gameObject.SetActive(false);
        volumetricPlayer.SetPlaybackState(VolumetricPlayer.PlaybackState.Stopped);

        extraVolumetricPlayers.SetActive(false);
        mainMenuPanel.SetActive(true);
        tutorialPanel.SetActive(false);

        volumetricPlayer.OnStepChanged.AddListener(SetUIElement);
        volumetricPlayer.OnStepChanged.AddListener(StepChanged);

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



    public void TogglePaused()
    {
        Debug.Log("Toggle paused in progression Man");
        Debug.Log(volumetricPlayer.GetPlaybackState());
        if (volumetricPlayer.GetPlaybackState() == VolumetricPlayer.PlaybackState.Playing)
        {
            Debug.Log(volumetricPlayer.GetPlaybackState());
            SetPaused();
        }
        else if (volumetricPlayer.GetPlaybackState() == VolumetricPlayer.PlaybackState.Paused)
        {
            Debug.Log(volumetricPlayer.GetPlaybackState());
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

    float playbackSpeed => volumetricPlayer.PlaybackSpeed;
    public void ToggleSlow()
    {
        if (playbackSpeed == 1)
        {
            StartCoroutine(SetSpeed(0.5f, 1));
        }
        else
        {
            StartCoroutine(SetSpeed(1f, 1));
        }
    }


    IEnumerator SetSpeed(float targetSpeed, float duration)
    {
        float startSpeed = volumetricPlayer.PlaybackSpeed;
        float startTime = Time.time;
        float endTime = startTime + duration;

        float curTime = startTime;
        while (curTime <= endTime)
        {
            curTime = Time.time;
            float u = Mathf.InverseLerp(startTime, endTime, curTime);

            float speed = Mathf.Lerp(startSpeed, targetSpeed, u);
            volumetricPlayer.PlaybackSpeed = speed;
            if(discoBall)discoBall.speed = speed;

            yield return new WaitForEndOfFrame();
        }
    }




}
