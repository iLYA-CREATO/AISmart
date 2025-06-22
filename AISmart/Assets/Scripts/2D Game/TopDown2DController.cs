using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDown2DController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 15f;
    [SerializeField] private float currentSpeed = 0f;

    [Header("Camera Settings")]
    [SerializeField] private float cameraFollowSpeed = 5f;
    [SerializeField] private Vector2 cameraOffset = new Vector2(0f, 0f);
    [SerializeField] private float cameraZoom = 5f;
    [SerializeField] private float minZoom = 3f;
    [SerializeField] private float maxZoom = 10f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Camera playerCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // ��������� ���������� ��� 2D
        rb.freezeRotation = true; // ��������� ��������

        playerCamera = Camera.main;
        SetupCamera();
    }

    private void Update()
    {
        // �������� ����
        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        // ��������� ���� ������
        HandleCameraZoom();
    }

    private void FixedUpdate()
    {
        // �������� ���������
        MoveCharacter();

        // ���������� ������
        FollowPlayerWithCamera();
    }

    private void MoveCharacter()
    {
        if (moveInput.magnitude > 0.1f)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, acceleration * Time.fixedDeltaTime);
            rb.linearVelocity = moveInput * currentSpeed;
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, deceleration * Time.fixedDeltaTime);
            rb.linearVelocity = rb.linearVelocity.normalized * currentSpeed;
        }
    }

    private void SetupCamera()
    {
        playerCamera.orthographic = true;
        playerCamera.orthographicSize = cameraZoom;
        playerCamera.transform.position = new Vector3(
            transform.position.x + cameraOffset.x,
            transform.position.y + cameraOffset.y,
            -10f // ������ ������� ������
        );
    }

    private void FollowPlayerWithCamera()
    {
        Vector3 targetPosition = new Vector3(
            transform.position.x + cameraOffset.x,
            transform.position.y + cameraOffset.y,
            playerCamera.transform.position.z
        );

        playerCamera.transform.position = Vector3.Lerp(
            playerCamera.transform.position,
            targetPosition,
            cameraFollowSpeed * Time.fixedDeltaTime
        );
    }

    private void HandleCameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            cameraZoom -= scroll * 2f;
            cameraZoom = Mathf.Clamp(cameraZoom, minZoom, maxZoom);
            playerCamera.orthographicSize = cameraZoom;
        }
    }
}