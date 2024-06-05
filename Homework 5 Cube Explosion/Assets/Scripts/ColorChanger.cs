using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}