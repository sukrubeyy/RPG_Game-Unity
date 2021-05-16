using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private float zoomCurrent = 10f;
    public float  pitch=2f;

    public float zoomSpeed = 4f;
    public float maxZoom = 15f;
    public float minZoom = 5f;

    public float camRotateSpeed=150f;
    private float inputCamHorizontal=0f;

    private void Update()
    {
        zoomCurrent -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoomCurrent = Mathf.Clamp(zoomCurrent, minZoom, maxZoom);

        inputCamHorizontal -= Input.GetAxis("Horizontal") * camRotateSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        //Aradaki farkı bulup zoomCurrent ile çarpıp kameramızın pozisyonunu belirliyoruz
        transform.position = target.position - offset * zoomCurrent;
        //Hedef objeye bakması için her frame'de döndürür. Y ekseninde farklılık yaratır.
        transform.LookAt(target.position+Vector3.up*pitch);
        //
        transform.RotateAround(target.position, Vector3.up, inputCamHorizontal);
    }
}
