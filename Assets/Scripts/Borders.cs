using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    static Camera cam = Camera.main;
    static Vector3 minBorder = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
    static Vector3 maxBorder = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
    public static Vector2 minPos = new Vector2(minBorder.x + 0.5f, minBorder.y+ 0.5f);
    public static Vector2 maxPos = new Vector2(maxBorder.x - 0.5f, maxBorder.y - 0.5f);
}
