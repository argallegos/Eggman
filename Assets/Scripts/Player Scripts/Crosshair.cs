using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField] Texture2D image;
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;

    public Vector3 crosshairPos, testPos;

    public float x, y, z;


    float lookHeight;
    public float crosshairY;

    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        testPos = transform.position;
    }


    public void LookHeight (float value)
    {
        lookHeight += value;
        if (lookHeight > maxAngle || lookHeight < minAngle)
            lookHeight -= value;

    }

    public void OnGUI()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
        GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y - lookHeight, size, size), image);
        crosshairY = screenPosition.y;
        crosshairPos.Set(screenPosition.x, screenPosition.y-lookHeight*-1f, 0f);

    }



}
