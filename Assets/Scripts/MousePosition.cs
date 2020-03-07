using System;
using UnityEngine;
using UnityEngine.Events;

public class MousePosition : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private MouseMoved _onMouseMoved;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _onMouseMoved.Invoke(_camera.ScreenToWorldPoint(Input.mousePosition));
    }
}

[Serializable]
internal class MouseMoved : UnityEvent<Vector3>
{
}