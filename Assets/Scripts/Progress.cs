using System.Reflection;
using Microsoft.Win32.SafeHandles;
using UnityEditor;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress instance;
    public float acceleration;
    public float InitialSpeed = 0;
    private float count = 0;
    private float speedF = 0;
    public float Distance
    {
        get { return InitialSpeed * count + (acceleration * Mathf.Pow(count,2)) / 2; }
        set { }
    }
    public float Speed
    {
        get { return speedF; }
    }
    public float Moment
    {
        get { return count; }
        set { }
    }
    private void Awake()
    {
        instance = this;
        count += Time.deltaTime;
        speedF = InitialSpeed + acceleration * count;
    }
    private void Update()
    {
        count += Time.deltaTime;
        speedF = InitialSpeed + acceleration * count;
    }
}
