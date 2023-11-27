using UnityEngine;
using UnityEngine.InputSystem;

namespace NaughtyCharacter
{
    public class PlayerCamera : MonoBehaviour
    {
        [Tooltip("How fast the camera rotates around the pivot. Value <= 0 are interpreted as instant rotation")]
        public float RotationSpeed = 0.0f;
        public float PositionSmoothDamp = 0.0f;
        public Transform Rig; // The root transform of the camera rig
        public Transform Pivot; // The point at which the camera pivots around
        public Camera Camera;

        private Vector3 _cameraVelocity;

        private bool isCursorLocked = true;

        private void Start()
        {
            LockUnlockCursor();
        }

        private void Update()
        {
            // Sprawdzamy, czy Escape zosta³ wciœniêty, aby odblokowaæ kursor myszy
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                isCursorLocked = !isCursorLocked;
                LockUnlockCursor();
            }
        }

        private void LockUnlockCursor()
        {
            Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isCursorLocked;
        }

        public void SetPosition(Vector3 position)
        {
            Rig.position = Vector3.SmoothDamp(Rig.position, position, ref _cameraVelocity, PositionSmoothDamp);
        }

        public void SetControlRotation(Vector2 controlRotation)
        {
            // Y Rotation (Yaw Rotation)
            Quaternion rigTargetLocalRotation = Quaternion.Euler(0.0f, controlRotation.y, 0.0f);

            // X Rotation (Pitch Rotation)
            Quaternion pivotTargetLocalRotation = Quaternion.Euler(controlRotation.x, 0.0f, 0.0f);

            if (RotationSpeed > 0.0f)
            {
                Rig.localRotation = Quaternion.Slerp(Rig.localRotation, rigTargetLocalRotation, RotationSpeed * Time.deltaTime);
                Pivot.localRotation = Quaternion.Slerp(Pivot.localRotation, pivotTargetLocalRotation, RotationSpeed * Time.deltaTime);
            }
            else
            {
                Rig.localRotation = rigTargetLocalRotation;
                Pivot.localRotation = pivotTargetLocalRotation;
            }
        }
    }
}
