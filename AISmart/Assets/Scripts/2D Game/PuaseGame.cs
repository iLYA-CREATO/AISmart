using UnityEngine;
using UnityEngine.InputSystem;

public class PuaseGame : MonoBehaviour
{
    public GameObject panelPause;

    public TopDown2DController topDown2DController;
    public EnemyAI enemyAI;

    public MoveCharacter moveCharacter;
    public MoveCamera moveCamera;
    public AudioListener audioListener;

    public bool is2DLevel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panelPause.SetActive(!panelPause.activeSelf);

            if(is2DLevel)
            {
                topDown2DController.enabled = !topDown2DController.enabled;
                enemyAI.enabled = !enemyAI.enabled;
            }
            else
            {
                moveCharacter.enabled = !moveCharacter.enabled;
                moveCamera.enabled = !moveCamera.enabled;
                audioListener.enabled = !audioListener.enabled;
            }

            if (panelPause.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
