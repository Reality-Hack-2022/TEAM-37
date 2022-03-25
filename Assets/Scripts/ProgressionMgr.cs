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

    public void StartTutorial(int whichTutorial = 0)
    {
        Debug.Log("Starting Tutorial in Progression MGR");
        mainMenuPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        volumetricPlayer.OnStepChanged.AddListener(SetUIElement);
        volumetricPlayer.OnStepChanged.AddListener(StepChanged);
        volumetricPlayer.CurStep = 0;
        SetUIElement();
        //Tutorials[whichTutorial].PlayTutorial();
    }

    public void StepChanged(int i = 0)
    {

    }
    public void SetUIElement(int i = 0)
    {
        if (contentPanels[i])
            contentPoster.sprite = contentPanels[i];
    }




}
