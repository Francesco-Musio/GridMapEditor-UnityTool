using UnityEngine;
using UnityEditor;
using Map;

[CustomPropertyDrawer(typeof(MatrixLayout))]
public class CustomMatrixLayout : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {

        if (GUI.Button(new Rect(_position.x, _position.y + 5f, _position.width * 0.2f, _position.height), new GUIContent("Edit Map")))
        {
            SerializedProperty rows = _property.FindPropertyRelative("rows");
            rows.arraySize = _property.FindPropertyRelative("mapHeight").intValue;
            for (int i = 0; i < rows.arraySize; i++)
            {
                SerializedProperty row = rows.GetArrayElementAtIndex(i).FindPropertyRelative("row");
                row.arraySize = _property.FindPropertyRelative("mapWidth").intValue;
            }
            
            MapEditorWindow.Show(_property);
        }

    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f;
    }
}
