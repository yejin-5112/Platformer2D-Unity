using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    Vector3 offset;
    public Transform playerTransform;
    public float fixedYPosition;
    [Range(0f, 1f)]
    public float smoothValue;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;

        fixedYPosition = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 targetPosition = playerTransform.position + offset;
        targetPosition.y = fixedYPosition;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothValue);

        //백터의 합
        transform.position = smoothPosition;
    }
}
