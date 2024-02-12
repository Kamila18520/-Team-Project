using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeController : MonoBehaviour
{
  

    [SerializeField] GameObject Blade;
    [SerializeField] GameObject Center;
    [SerializeField] GameObject Point;

    [SerializeField] float TimeToStart;
    [SerializeField] float TimeToFullRotateBlade;
    [SerializeField] float Speed;
    [SerializeField] bool SameShowHideSpeed=false;
    [SerializeField] float TimeThatBladeIsShown;
    [SerializeField] float TimeThatBladeIsHide;
    [SerializeField] bool Showing = true;


    private float TimeBetweenShowHideBlade;

    // Start is called before the first frame update

    private void Start()
    {
        if (SameShowHideSpeed)
        {
            SetTimeBetweenShowHideBlade();
        }

        MoveBlade();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeToFullRotateBlade !=0)
        {
        float rotationAmount = TimeToFullRotateBlade * 360f * Time.deltaTime;
        Blade.transform.transform.eulerAngles = new Vector3(90, Blade.transform.eulerAngles.y + rotationAmount, 0f);

        }

 
    }

    void MoveBlade()
    {
 
                StartCoroutine(MoveObject(Blade.transform, Center.transform.position, Point.transform.position, TimeToStart));

       
    }

    IEnumerator MoveObject(Transform obj, Vector3 startPos, Vector3 endPos, float timeToMove)
    {
        
        Showing = !Showing;
        float t = 0f;

        while (t < Speed)
        {
            t += Time.deltaTime / timeToMove;
            obj.position = Vector3.Lerp(startPos, endPos, t * t); // Interpolacja kwadratowa.

            yield return null;
        }

        // Wait for a short delay at the destination.

        

        var SetTime = Showing ? TimeBetweenShowHideBlade = TimeThatBladeIsShown : TimeBetweenShowHideBlade = TimeThatBladeIsHide;

        if(SameShowHideSpeed)
        {
            SetTimeBetweenShowHideBlade();
        }
        yield return new WaitForSeconds(TimeBetweenShowHideBlade);

        // Start moving back.
        StartCoroutine(MoveObject(obj, endPos, startPos, timeToMove));
    }

    private void SetTimeBetweenShowHideBlade()
    {
        TimeBetweenShowHideBlade = TimeThatBladeIsShown;

    }


}

