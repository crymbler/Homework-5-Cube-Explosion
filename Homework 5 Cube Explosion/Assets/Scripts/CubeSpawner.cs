using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;
    [SerializeField] private float _reduceSize;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Cube _cube;

    private void Start()
    {
        _cube.Clicked += SpawnCubes;
    }

    public void SpawnCubes(Cube cube)
    {
        cube.Clicked -= SpawnCubes;

        int random = Random.Range(_minCount, _maxCount);

        for (int i = 0; i < random; i++)
        {
            Cube cubeToInstance = Instantiate(cube, cube.transform.position, Random.rotation);

            cubeToInstance.Clicked += SpawnCubes;

            cubeToInstance.transform.localScale *= _reduceSize;

            cubeToInstance.SetMaterial(new Color(Random.value, Random.value, Random.value));

            cubeToInstance.AddForce(_explosionForce);
        }
    }
}