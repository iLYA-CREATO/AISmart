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


    Ray ray;
    RaycastHit hit;


    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // ���������, ���� �� ������ ���������
        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {
            textAction.gameObject.SetActive(true); 

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("������ ������");
            }
        }
        else
        {
            textAction.gameObject.SetActive(false);
        }
    }
}
