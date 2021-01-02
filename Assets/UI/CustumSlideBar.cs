using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(SlideBar))]
public class CustumSlideBar : Editor
{
    private SlideBar slide ;
    public override void OnInspectorGUI()
    {
        slide = (SlideBar)target;

        slide.fill = (Image)EditorGUILayout.ObjectField("Fill", slide.fill, typeof(Image), true);
        slide.value = EditorGUILayout.Slider("Value", slide.value, 0f, 1f);
    }
    
}

