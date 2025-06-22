using NUnit.Framework;
using TMPro;
using UnityEngine;

public class GetScreammer : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private TextMeshProUGUI textAction;
    
    [SerializeField]
    private SceneLoaded sceneLoaded;

    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Проверяем, есть ли вообще попадание
        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {
            textAction.gameObject.SetActive(true); 

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Монстр пойман");
                sceneLoaded.LoadScene2D();
            }
        }
        else
        {
            textAction.gameObject.SetActive(false);
        }
    }
}
