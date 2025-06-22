using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField]
    private GameObject torch;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            torch.SetActive(!torch.activeSelf);
        }
    }
}
