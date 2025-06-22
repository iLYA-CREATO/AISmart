using System;
using UnityEngine;

public class TrigCollider : MonoBehaviour
{
    public static event Action<string> OnTrigColldier;
    [SerializeField]
    private string codeMessage;
    private void OnTriggerEnter(Collider other)
    {
        OnTrigColldier?.Invoke(codeMessage);
    }
}
