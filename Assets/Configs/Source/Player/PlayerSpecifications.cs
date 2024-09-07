using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSpecifications", menuName = "Player/Specifications")]
public class PlayerSpecifications : ScriptableObject
{
    [Header("Movement")]
    [SerializeField]
    private float _walkSpeed;

    public float WalkSpeed { get => _walkSpeed; }

    [SerializeField]
    private float _crouchWalkSpeed;

    public float CrouchWalkSpeed { get => _crouchWalkSpeed; }
    
    [SerializeField]
    private float _runSpeed;

    public float RunSpeed { get => _runSpeed; }

    [SerializeField]
    private float _sprintSpeed;

    public float SprintSpeed { get => _sprintSpeed; }

    [SerializeField]
    private float _rollSpeed;

    public float RollSpeed { get => _rollSpeed; }
}
