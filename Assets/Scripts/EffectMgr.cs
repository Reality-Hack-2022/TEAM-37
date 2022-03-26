using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EffectName { Typing, RightShot, Approach, LeftShot, Step1, Step2, Step3, Step4, Step5, Performance }

[System.Serializable]
public class EffectTrigger
{
   public EffectName name;
}

[System.Serializable]
public class EffectEvent : UnityEvent<EffectTrigger> { } //effect list

public class EffectMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
