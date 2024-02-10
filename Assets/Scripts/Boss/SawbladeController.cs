using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeController : MonoBehaviour
{
    [SerializeField] GameObject Blade;
    [SerializeField] GameObject Center;
    [SerializeField] GameObject Point;

    [SerializeField] float TimeToStart;
    [SerializeField] float Speed;

    private bool isMoving = false;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time + TimeToStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime && !isMoving)
        {
            isMoving = true;
            MoveBlade();
        }
    }

    void MoveBlade()
    {
        StartCoroutine(MoveObject(Blade.transform, Center.transform.position, Point.transform.position, TimeToStart));
    }

    IEnumerator MoveObject(Transform obj, Vector3 startPos, Vector3 endPos, float timeToMove)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            obj.position = Vector3.Lerp(startPos, endPos, t * t); // Interpolacja kwadratowa.

            // Obrót tylko wokó³ osi Y w zale¿noœci od prêdkoœci.
            float rotationAmount = Speed * 360f * Time.deltaTime;
            obj.Rotate(Vector3.up, rotationAmount);

            yield return null;
        }

        // Optional: You can perform additional actions after reaching the destination.

        // Wait for a short delay at the destination.
        yield return new WaitForSeconds(1.0f);

        // Start moving back.
        StartCoroutine(MoveObject(obj, endPos, startPos, timeToMove));
    }
}

