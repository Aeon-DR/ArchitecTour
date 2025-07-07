using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] _cameras;
    [SerializeField] private GameObject _dotPrefab;
    [SerializeField] private Transform _cameraCarousel;

    [SerializeField] private Color _activeColor = Color.white;
    [SerializeField] private Color _inactiveColor = Color.gray;

    private List<Image> _dots = new List<Image>();
    private int _currentCamera = 0;

    private void Start()
    {
        CreateDots();
        UpdateCameraView();
    }

    public void NextCamera()
    {
        _currentCamera = (_currentCamera + 1) % _cameras.Length;
        UpdateCameraView();
    }

    public void PreviousCamera()
    {
        _currentCamera = _currentCamera == 0 ? _cameras.Length - 1 : _currentCamera - 1;
        UpdateCameraView();
    }

    private void UpdateCameraView()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            bool isActive = _currentCamera == i;
            _cameras[i].gameObject.SetActive(isActive);
            _dots[i].color = isActive ? _activeColor : _inactiveColor;
        }
    }

    private void CreateDots()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            GameObject dot = Instantiate(_dotPrefab, _cameraCarousel);
            _dots.Add(dot.GetComponent<Image>());
        }
    }
}
