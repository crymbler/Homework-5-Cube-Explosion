using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;
    [SerializeField] private float _reduceChance;

    private Renderer _renderer;
    private Rigidbody _rigidbody;
    
    public Action<Cube> Clicked;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (Random.Range(0f, 1f) > _splitChance)
        {
            Destroy(gameObject);

            return;
        }

        _splitChance *= _reduceChance;

        Clicked?.Invoke(this);

        Destroy(gameObject);
    }

    public void SetMaterial(Color color)
    {
        _renderer.material.color = color;
    }

    public void AddForce(float explosionForce)
    {
        _rigidbody.AddForce(transform.position.normalized * explosionForce, ForceMode.Impulse);
    }
}