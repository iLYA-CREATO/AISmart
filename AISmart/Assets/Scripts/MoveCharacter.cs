using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runMoveSpeed = 30f;
    [SerializeField] private float gravityValue = -5;

    float moveX;
    float moveY;
    float moveZ;
    Vector3 velocity;

    Vector3 previousPosition;
    [SerializeField] private bool lockController;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        
        if (lockController == false)
        {
            moveZ = Input.GetAxis("Vertical");
            if (transform.position.y > 1.1f)
            {
                moveY = gravityValue;
            }

            MovePlayer(moveX, moveY, moveZ);

            velocity.y += gravityValue * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);

            previousPosition = transform.position;
        }
       
    }
    private void MovePlayer(float moveX, float moveY, float moveZ)
    {
        Vector3 move =  transform.forward * moveZ;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runMoveSpeed;
        }
       else
        {
            moveSpeed = 2f;
        }

        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    public void LockController(bool isLock)
    {
        lockController = isLock;
    }
}