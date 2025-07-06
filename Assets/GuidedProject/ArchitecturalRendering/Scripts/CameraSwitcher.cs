using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] _cameras;
    private int _currentCamera;

    private void Start()
    {
        _currentCamera = 0;
    }

    public void NextCamera()
    {
        _currentCamera = (_currentCamera + 1) % _cameras.Length;
        SwitchCamera();
    }

    public void PreviousCamera()
    {
        _currentCamera = _currentCamera == 0 ? _cameras.Length - 1 : _currentCamera - 1;
        SwitchCamera();
    }

    private void SwitchCamera()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            bool isActive = _currentCamera == i;
            _cameras[i].gameObject.SetActive(isActive);
        }
    }
}
