using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float positionPitchFactor = .75f;
    float movementPitchFactor = 20f;
    float movementRollFactor = -25f;
    float movementYawFactor = .7f;
    float controlSpeed = 50f;
    float verticalThrow;
    float horizontalThrow;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitch = GetPitch();
        float roll = GetRoll();
        float yaw = GetYaw();
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);// yaw, roll);
    }

    float GetRoll()
    {
        return horizontalThrow * movementRollFactor;
    }

    float GetYaw()
    {
        return transform.localPosition.x * movementYawFactor;
    }

    float GetPitch()
    {
        var pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        var pitchDueToMovement = verticalThrow * movementPitchFactor;
        var pitch = pitchDueToMovement + pitchDueToPosition;
        return pitch;
    }

    void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        var newXPosition = Mathf.Clamp(transform.localPosition.x + horizontalThrow * Time.deltaTime * controlSpeed, -16f, 16f);
        var newYPosition = Mathf.Clamp(transform.localPosition.y + verticalThrow * Time.deltaTime * controlSpeed, -8f, 12f);
        transform.localPosition = new Vector3(newXPosition, newYPosition, transform.localPosition.z);
    }
}
