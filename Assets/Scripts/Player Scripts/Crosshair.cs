using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alex Gallegos crosshair script

public class Crosshair : MonoBehaviour {

    [SerializeField] Texture2D image;
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;

    [HideInInspector]
    public Vector3 crosshairPos;

    public PlayerScript player;

    float lookHeight;

    public void LookHeight (float value)
    {
        lookHeight += value;
        if (lookHeight > maxAngle || lookHeight < minAngle)
            lookHeight -= value;

    }

    public void OnGUI()
    {
        float offset = size / 2;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height/2;
        if (!player.eggMode){
            GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y - lookHeight, size, size), image);
            crosshairPos.Set(screenPosition.x + offset, (screenPosition.y - lookHeight * -1f - offset), 0f);
        }
    }



}
