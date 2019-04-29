using UnityEngine;
using UnityEditor;
using Map;

public class MapEditorWindow : EditorWindow
{
    SerializedProperty property;

    public static void Show(SerializedProperty _property)
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(MapEditorWindow));
        (window as MapEditorWindow).property = _property;
    }

    private void OnGUI()
    {
        Rect newPosition = new Rect();
        newPosition.x = 36f;
        newPosition.y = 18f;
        newPosition.height = 18f;
        newPosition.width = 18f;

        this.minSize = new Vector2(
            Mathf.Max(18f * (property.FindPropertyRelative("mapWidth").intValue + 3), 116f), 
            18f * (property.FindPropertyRelative("mapHeight").intValue + 10));
        this.maxSize = this.minSize;

        #region Grid Section
        // draw upper indexes
        for (int i = 0; i < property.FindPropertyRelative("mapWidth").intValue; i++)
        {
            EditorGUI.LabelField(newPosition, i.ToString());
            newPosition.x += 18f;
        }

        newPosition.x = 18f;
        newPosition.y += 18f;

        // get map variable from MapData
        SerializedProperty rows = property.FindPropertyRelative("rows");

        // Get the first row
        for (int j = 0; j < property.FindPropertyRelative("mapHeight").intValue; j++)
        {
            SerializedProperty row = rows.GetArrayElementAtIndex(j).FindPropertyRelative("row");
            EditorGUI.LabelField(newPosition, j.ToString());
            newPosition.x += 18f;
            for (int i = 0; i < property.FindPropertyRelative("mapWidth").intValue; i++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(i), GUIContent.none);
                newPosition.x += 18f;
            }

            newPosition.x = 18f;
            newPosition.y += 18f;
        }
        #endregion

        #region Start Section
        newPosition.width = 18f * (property.FindPropertyRelative("mapWidth").intValue + 3);
        EditorGUI.LabelField(newPosition, "Start Position");
        newPosition.y += 18f;
        
        Rect tempRect = new Rect(newPosition.x, newPosition.y, newPosition.width - 36f, newPosition.height);
        EditorGUIUtility.labelWidth = tempRect.width - 18f * property.FindPropertyRelative("mapWidth").intValue;
        property.FindPropertyRelative("startX").intValue = EditorGUI.IntField(tempRect, new GUIContent("x"), property.FindPropertyRelative("startX").intValue);
        newPosition.y += 18f;

        tempRect = new Rect(newPosition.x, newPosition.y, newPosition.width -36f, newPosition.height);
        property.FindPropertyRelative("startY").intValue = EditorGUI.IntField(tempRect, "y", property.FindPropertyRelative("startY").intValue);
        newPosition.y += 18f;
        #endregion

        #region End Section
        newPosition.width = 18f * (property.FindPropertyRelative("mapWidth").intValue + 3);
        EditorGUI.LabelField(newPosition, "End Position");
        newPosition.y += 18f;

        tempRect = new Rect(newPosition.x, newPosition.y, newPosition.width - 36f, newPosition.height);
        EditorGUIUtility.labelWidth = tempRect.width - 18f * property.FindPropertyRelative("mapWidth").intValue;
        property.FindPropertyRelative("endX").intValue = EditorGUI.IntField(tempRect, new GUIContent("x"), property.FindPropertyRelative("endX").intValue);
        newPosition.y += 18f;

        tempRect = new Rect(newPosition.x, newPosition.y, newPosition.width - 36f, newPosition.height);
        property.FindPropertyRelative("endY").intValue = EditorGUI.IntField(tempRect, "y", property.FindPropertyRelative("endY").intValue);
        newPosition.y += 18f;
        #endregion

        #region Reset Button
        newPosition.y += 3f;

        if (GUI.Button(new Rect(newPosition.x, newPosition.y, 80f, newPosition.height), new GUIContent("Reset Map")))
        {
            SerializedProperty matrixRows = property.FindPropertyRelative("rows");
            matrixRows.arraySize = property.FindPropertyRelative("mapHeight").intValue;
            for (int i = 0; i < matrixRows.arraySize; i++)
            {
                SerializedProperty row = matrixRows.GetArrayElementAtIndex(i).FindPropertyRelative("row");
                row.arraySize = property.FindPropertyRelative("mapWidth").intValue;

                for (int j = 0; j < row.arraySize; j++)
                {
                    row.GetArrayElementAtIndex(j).boolValue = false;
                }
            }
        }
        #endregion
    }
}
