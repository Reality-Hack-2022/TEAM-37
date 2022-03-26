using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Tutorial", menuName = "Tutorial Data")]
public class TutorialData : ScriptableObject
{
    public GameObject volumetricPlayerPrefab;
    public Vector3 spawnOffset = Vector3.zero;
    public TutorialClips tutorialClips;

    public void PlayTutorial()
    {
        SpawnVolumetricPlayer();
    }
    void SpawnVolumetricPlayer()
    {
        GameObject volumetricPlayer = Instantiate(volumetricPlayerPrefab,
                                                    ProgressionMgr.instance.spawnPoint.position+spawnOffset,
                                                    ProgressionMgr.instance.spawnPoint.rotation);

        ProgressionMgr.instance.volumetricPlayer = volumetricPlayer.GetComponent<VolumetricPlayer>();
    }
    
}
