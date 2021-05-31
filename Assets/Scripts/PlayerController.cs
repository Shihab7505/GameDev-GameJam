using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] float angleRange = 90f;
    [SerializeField] float cameraPitch = 0.0f;
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float walkSpeed = 50f;
    [SerializeField] bool lockCursor = true;
    [SerializeField] [Range(0f,0.5f)]float moveSmoothTime = .3f;
    [SerializeField] [Range(0f,0.5f)]float mouseSmoothTime = .03f;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    CharacterController controller = null;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }
    void UpdateMouseLook()
    {
        Vector2 targetmouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta,targetmouseDelta,ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -=  currentMouseDelta.y * mouseSensitivity * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch,-angleRange,angleRange);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate    (Vector3.up *  currentMouseDelta.x * mouseSensitivity* Time.deltaTime);
    }

    void UpdateMovement()
    {
        Vector2 targetDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDirection.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir,targetDirection, ref currentDirVelocity, moveSmoothTime);

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed;
        controller.Move(velocity * Time.deltaTime);
    }
}
