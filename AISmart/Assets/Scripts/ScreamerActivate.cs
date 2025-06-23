using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerActivate : MonoBehaviour
{
    [SerializeField]
    private string code1;
    [SerializeField]
    private string code3;
    [SerializeField]
    private string code4;


    [SerializeField]
    private GameObject screamer;
    [SerializeField]
    private float timeScreamer;

    [SerializeField]
    [Header("Просто страшный звук")]
    private Audio audio;
    [SerializeField]
    [Header("Звук появления монстра")]
    private Audio audio2;

    [SerializeField]
    private List<LightComponent> listLight;

    [SerializeField]
    private LightSwitcher lightSwitcher;


    private bool isActiveScreammer;
    private void OnEnable()
    {
        TrigCollider.OnTrigColldier += ScreamerCode;
    }

    private void OnDisable()
    {
        TrigCollider.OnTrigColldier -= ScreamerCode;
    }
    private void ScreamerCode(string codeMessage)
    {
        if(codeMessage == code1)
        {
            PlayAudio._PlayAudio(audio.AudioClip, audio.audioSource);
        }
        else if (codeMessage == code3)
        {
            for (int i = 0; i < listLight.Count; i++)
            {
                lightSwitcher.SwitchLightOff(listLight[i]);
            }
        }
        else if (codeMessage == code4)
        {
            if(isActiveScreammer == false)
            {
                StartCoroutine(ActiveteScreamer(timeScreamer, screamer));
            }
            isActiveScreammer = true;
        }
    }


    private IEnumerator ActiveteScreamer(float time, GameObject gameObject)
    {
        PlayAudio._PlayAudio(audio2.AudioClip, audio2.audioSource);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.SetActive(true);
    }
}

[Serializable]
public class Audio
{
    public AudioSource audioSource;
    public AudioClip AudioClip;
}