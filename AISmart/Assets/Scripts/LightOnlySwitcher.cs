using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnlySwitcher : MonoBehaviour
{
    [SerializeField]
    private bool _switch;

    [SerializeField]
    [Header("Скорость переключения света")]
    private float timer;

    [SerializeField]
    private LightComponent lightComponent;

    [SerializeField]
    private LightDopData lightDopData;

    private void Start()
    {
        if (_switch)
        {
            StartCoroutine(StartSwitcher());
        }
    }

    
    private IEnumerator StartSwitcher()
    {
        while(true)
        {
            for (int i = 0; i < lightComponent.rendererCurrentLamp.Count; i++)
            {
                lightComponent.rendererCurrentLamp[i].material = lightDopData.materialLightOff;
            }
            PlayAudio._PlayAudio(lightDopData.soundLight, lightComponent.lightSource);
            lightComponent.light.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(timer);
            for (int i = 0; i < lightComponent.rendererCurrentLamp.Count; i++)
            {
                lightComponent.rendererCurrentLamp[i].material = lightDopData.materialLightOn;
            }
            lightComponent.light.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(timer);
        }
    }
}
