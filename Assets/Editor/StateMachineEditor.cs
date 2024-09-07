using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Player;

[CustomEditor(typeof(PlayerStateMachine))]
public class StateMachineEditor : Editor
{
    public VisualTreeAsset _visualTreeAsset;

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();

        _visualTreeAsset.CloneTree(root);

        return root;
    }
}
