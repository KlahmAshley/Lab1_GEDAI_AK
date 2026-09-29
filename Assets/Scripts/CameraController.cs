using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0f, 1f)]
    public float smoothTime;

    public Vector3 positionOffset;

    public Transform topLeftBound;
    public Transform bottomRightBound;

    private Camera cam;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + positionOffset;

        float camHeight = cam.orthographicSize * 2;
        float camWidith = camHeight * cam.aspect;

        float minX = topLeftBound.position.x + camWidith / 2;
        float maxX = bottomRightBound.position.x - camWidith / 2;
        float minY = bottomRightBound.position.y + camHeight / 2;
        float maxY = topLeftBound.position.y - camHeight / 2;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {
            cam.transform.SetLocalPositionAndRotation(transform.position, transform.rotation);  


        }
    }


   

    public float duration = 1f;

   public IEnumerator Shaking(float duration, float magnitude)
    {
        Vector3 orginalPos = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;


            transform.localPosition = new Vector3(x, y, orginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = orginalPos;

    }

}


