using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] _cameras;
    private int _currentCamera;

    private void Start()
    {
        _currentCamera = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) SwitchCamera();
    }

    private void SwitchCamera()
    {
        _currentCamera = (_currentCamera + 1) % _cameras.Length;

        for (int i = 0; i < _cameras.Length; i++)
        {
            bool isActive = _currentCamera == i;
            _cameras[i].gameObject.SetActive(isActive);
        }
    }
}
