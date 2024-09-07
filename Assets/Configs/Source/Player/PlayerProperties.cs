using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProperties", menuName = "Player/Properties")]
public class PlayerProperties : ScriptableObject
{
    [Header("Movement")]
    [SerializeField]
    [Range(0, 1)]
    private float _moveThreshold;
    public float MoveThreshold { get => _moveThreshold; }

    [SerializeField]
    [Range(0, 1)]
    private float _runThreshold;
    public float RunThreshold { get => _runThreshold; }
}
