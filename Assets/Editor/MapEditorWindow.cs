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
        int width = property.FindPropertyRelative("mapWidth").intValue;
        int height = property.FindPropertyRelative("mapHeight").intValue;

        Rect newPosition = new Rect();
        newPosition.x = 18f;
        newPosition.y = 18f;

        this.minSize = new Vector2(18f * width, 18f * height);

        // get map variable from MapData
        SerializedProperty rows = property.FindPropertyRelative("rows");

        // Get the first row
        for (int j = 0; j < height; j++)
        {
            SerializedProperty row = rows.GetArrayElementAtIndex(j).FindPropertyRelative("row");
            newPosition.height = 18f;
            newPosition.width = 18f;
            for (int i = 0; i < width; i++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(i), GUIContent.none);
                newPosition.x += 18f;
            }

            newPosition.x = 18f;
            newPosition.y += 18f;
        }
    }
}
