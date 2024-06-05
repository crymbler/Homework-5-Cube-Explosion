using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExplosion _cubeExplosion;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit.TryGetComponent(out Cube cube))
                {
                    if (Random.Range(0f, 1f) < cube.SplitChance)
                    {
                        List<Cube> newCubes = _cubeSpawner.SpawnCubes(cube);

                        _cubeExplosion.Explode(newCubes, cube.transform.position);
                    }

                    Destroy(cube.gameObject);
                }
            }
        }
    }
}