using Cinemachine;
using Player;
using UnityEngine;

public class PlayerLookToTarget : MonoBehaviour
{
    private Transform _cameraTransform;
    public CinemachineFreeLook CinemachineFreeLook;
    private PlayerComponentProvider _componentProvider;
    private PlayerInputProvider _inputProvider;

    [SerializeField]
    private LayerMask _layerMask;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;

        _componentProvider = GetComponent<PlayerComponentProvider>();
        _inputProvider = _componentProvider.InputProvider;

        _inputProvider.OnCrouch += Look;
    }

    private void Look()
    {
        Vector3 cameraDirection = transform.position - _cameraTransform.position;
        cameraDirection.y = 0;
        cameraDirection = cameraDirection.normalized;

        RaycastHit raycastHit;

        if (Physics.SphereCast(transform.position, 3, cameraDirection, out raycastHit, 10, _layerMask))
        {
        }
    }

    private void OnDisable()
    {
        _inputProvider.OnCrouch -= Look;
    }
}
