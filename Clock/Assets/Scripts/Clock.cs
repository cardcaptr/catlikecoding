using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;
    
    [SerializeField]
    Material targetMaterial;

    private const float hoursToDegrees = -30f;
    private const float minutesToDegrees = -6f;
    private const float secondsToDegrees = -6f;

    private Color defaultColor = Color.blue;
    private Color _newColor = Color.green;
    private void Awake()
    {
        //var time =  DateTime.Now;
        //hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * time.Hour);
        //minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * time.Minute); 
        //secondsPivot.localRotation= Quaternion.Euler(0f, 0f, secondsToDegrees * time.Second);       
    }

    private void Start()
    {
        // Make sure the object has a renderer component
        if (targetMaterial== null)
        {
            Debug.LogError("The object does not exist!");
        }
    }
    Transform oldPos;
    private void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ChangeColor(_newColor);
            }
            else if (touch.phase == TouchPhase.Stationary)
            {   
                secondsPivot.Rotate(0f, 0f, 20f * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                ChangeColor(defaultColor);
            }
            
        }
        else{
                setToCurrentTime();
        }
    }

    public void ChangeColor(Color _color)
    {

        // Assign the new color to the material
        targetMaterial.SetColor("_Color", _color);
    }
    
    private void setToCurrentTime(){
        TimeSpan currentSpan = DateTime.Now.TimeOfDay;

        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float)currentSpan.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)currentSpan.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)currentSpan.TotalSeconds);
    }
}
