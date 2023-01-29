using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomerAI))]
public class CustomerAiEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CustomerAI AI = (CustomerAI)target;

        
    }
}
