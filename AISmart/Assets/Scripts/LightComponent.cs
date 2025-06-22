using System.Collections.Generic;
using UnityEngine;

public class LightComponent : MonoBehaviour
{
    [Header("������� �����")]
    public List<GameObject> lightObject;
    [Header("����")]
    public List<Renderer> rendererCurrentLamp;

    [Header("����")]
    public GameObject light;

    public AudioSource lightSource;
}
