using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 currentPos;

    public float speed;

    private void Start()
    {
        StartCoroutine(GoForward());
    }

    IEnumerator GoForward()
    {
        float elapsedTime = 0;
        float waitTime = speed;
        currentPos = transform.position;
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(currentPos, endPos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = endPos;
        StartCoroutine(GoBack());
        yield return null;
    }
    IEnumerator GoBack()
    {
        float elapsedTime = 0;
        float waitTime = speed;
        currentPos = transform.position;
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(currentPos, startPos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = startPos;
        StartCoroutine(GoForward());
        yield return null;
        
    }
}
