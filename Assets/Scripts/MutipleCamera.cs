using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class MutipleCamera : MonoBehaviour
{

    public List<Transform> Targets;
    public Vector3 offset;
    private float smoothtime = 0.5f;
    private Vector3 Velocity;
    public float Minzoom = 50f;
    public float Maxzoom = 10f;
    public float zoomlimiter = 50f;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Targets.Count == 0)
            return;
        move();
        zoom();
    }
    void zoom()
    {
        float NewZoom = Mathf.Lerp(Maxzoom, Minzoom, GetGreatestDistance() / zoomlimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, NewZoom, Time.deltaTime);
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(Targets[0].position, Vector3.zero);
        for (int i = 0; i < Targets.Count; i++)
        {
            bounds.Encapsulate(Targets[i].position);
        }
        return bounds.size.x;
            
    }
    void move()
    {
        Vector3 CenterPoint = GetCenterPoint();
        Vector3 Newpoint = CenterPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, Newpoint, ref Velocity, smoothtime);

    }
    Vector3 GetCenterPoint()
    {
        if (Targets.Count == 1)
            return Targets[0].position;
        var bounds = new Bounds(Targets[0].position, Vector3.zero);
        for (int i = 0; i < Targets.Count; i++)
        {
            bounds.Encapsulate(Targets[i].position);
        }
        return bounds.center;
    }
}
