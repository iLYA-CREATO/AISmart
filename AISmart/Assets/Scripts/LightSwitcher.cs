using UnityEngine;

public class LightSwitcher : MonoBehaviour 
{
    [SerializeField]
    private LightDopData lightDopData;
    public void SwitchLightOff(LightComponent lightComponent)
    {
        for (int i = 0; i < lightComponent.rendererCurrentLamp.Count; i++)
        {
            lightComponent.rendererCurrentLamp[i].material = lightDopData.materialLightOff;
        }
        PlayAudio._PlayAudio(lightDopData.soundLight, lightComponent.lightSource);
        lightComponent.light.gameObject.SetActive(false);
    }

    public void SwitchLightOn(LightComponent lightComponent)
    {
        for (int i = 0; i < lightComponent.rendererCurrentLamp.Count; i++)
        {
            lightComponent.rendererCurrentLamp[i].material = lightDopData.materialLightOn;
        }
        lightComponent.light.gameObject.SetActive(true);
    }
}
