using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    [SerializeField] private float timeToFullRotateGear = 2f; // Zmieni³em nazwê zmiennej na bardziej standardow¹
    [SerializeField] bool DirectionLeft = false;

    private void Update()
    {
        RotateGear();
    }

    private void RotateGear()
    {
        float rotationAmount = 360f / timeToFullRotateGear * Time.deltaTime;

        Quaternion deltaRotation;

        if (DirectionLeft)
        {
            deltaRotation = Quaternion.Euler(new Vector3(0f, rotationAmount, 0f));
        }
        else
        {
            deltaRotation = Quaternion.Euler(new Vector3(0f, -rotationAmount, 0f));
        }

        // Teraz mo¿esz u¿yæ deltaRotation dalej w kodzie...

        // Zastosuj obrót do obecnego kwaternionu obiektu
        transform.rotation *= deltaRotation;
    }
}
