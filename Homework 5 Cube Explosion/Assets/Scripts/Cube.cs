using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;

    public float SplitChance => _splitChance;

    public void SetSplitChance(float newSplitChance)
    {
        _splitChance = Mathf.Clamp(newSplitChance, 0, 1);
    }
}