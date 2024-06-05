using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;
    [SerializeField] private float _reduceSize;
    [SerializeField] private float _reduceChance;

    public List<Cube> SpawnCubes(Cube cube)
    {
        List<Cube> cubesToChange = new List<Cube>();

        int random = Random.Range(_minCount, _maxCount);

        cube.SetSplitChance(cube.SplitChance * _reduceChance);

        for (int i = 0; i < random; i++)
        {
            Cube cubeToInstance = Instantiate(cube, cube.transform.position, Random.rotation);

            cubeToInstance.transform.localScale *= _reduceSize;

            cubesToChange.Add(cubeToInstance);
        }

        return cubesToChange;
    }
}