using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InputMgr : MonoBehaviour
{

   public bool PlayOnStart = false;
   public int StartStep = -1;
    public GameObject volumeSlider;
    public GameObject playThroughSwitch;
    public GameObject tutorialPanel;
    public GameObject mainMenuPanel;

   void Start()
   {
      if(PlayOnStart)
         StartTutorial(StartStep);

      if(UIMgr.I)
      {
         UIMgr.I.OnUIItemSelected.AddListener(_OnUIItemSelected);
      }
   }

   void _OnUIItemSelected(UIItem item)
   {
      if(item.PanelType == UIPanel.Learn)
         StartTutorial(0);
      else if(item.PanelType == UIPanel.Play)
         StartTutorial(-1);
      else if (item.PanelType == UIPanel.Back)
         PreviousTutorialElement();
      else if (item.PanelType == UIPanel.Next)
         NextTutorialElement();
      else if (item.PanelType == UIPanel.Home)
         ExitTutorial();
      else if (item.PanelType == UIPanel.PauseToggle)
         TogglePaused();
      else if (item.PanelType == UIPanel.SlowToggle)
         ToggleSlow();

   }

    private void Update()
    {
        //IN THE MAIN MENU
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            StartTutorial(-1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartTutorial(0);
        }



        //WHEN THE VOLUMETRIC PLAYER IS RUNNING
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextTutorialElement();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousTutorialElement();
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePaused();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ExitTutorial();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ToggleSlow();
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

    public void ToggleSlow()
    {
        ProgressionMgr.instance.ToggleSlow(); 
    }

    public void NextTutorialElement()
    {
        if (!ProgressionMgr.instance.volumetricPlayer) return;
        Debug.Log("Go to next step.");
        ProgressionMgr.instance.volumetricPlayer.GotoNextStep();
    }
    public void PreviousTutorialElement()
    {
        if (!ProgressionMgr.instance.volumetricPlayer) return;
        Debug.Log("Go to previous step.");
        ProgressionMgr.instance.volumetricPlayer.GotoPreviousStep();
    }

    public void TogglePaused()
    {
        Debug.Log("Pause");
        //if (!ProgressionMgr.instance.volumetricPlayer) return;
        ProgressionMgr.instance.TogglePaused();
    }

    public void Restart()
    {
        if (!ProgressionMgr.instance.volumetricPlayer) return;
        //ProgressionMgr.instance.volumetricPlayer.SetStep(0);
        Debug.Log("Restart");
    }

    public void StartTutorial(int startStep = 0)
    {
        ProgressionMgr.instance.StartTutorial(startStep);
        //Debug.Log($"Start with {startStep}");
    }
    public void ExitTutorial()
    {
        ProgressionMgr.instance.ExitTutorial();

        Debug.Log("Exit");
    }






}
