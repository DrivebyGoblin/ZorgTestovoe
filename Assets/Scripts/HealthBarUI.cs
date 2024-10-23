using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    Canvas _canvas;

    private void Start()
    {      
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = Camera.main;
        _canvas.transform.localPosition = new Vector3(0f, 0.75f, 0f);
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _canvas.worldCamera.transform.forward);
    }
}
