using UnityEngine;

public class MovimentLayer : MonoBehaviour
{
    private Material material;
    private void Start() {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update() {
        material.SetFloat("_Distance",Progress.instance.Distance);
    }
}
