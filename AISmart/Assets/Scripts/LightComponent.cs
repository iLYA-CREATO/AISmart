using System.Collections.Generic;
using UnityEngine;

public class LightComponent : MonoBehaviour
{
    [Header("объекты лампы")]
    public List<GameObject> lightObject;
    [Header("Свет")]
    public List<Renderer> rendererCurrentLamp;

    [Header("Свет")]
    public GameObject light;

    public AudioSource lightSource;
}
