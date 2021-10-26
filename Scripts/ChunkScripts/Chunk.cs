using System.Collections;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform Begin => _begin;
    public Transform End => _end;

    [SerializeField] private Transform _begin;
    [SerializeField] private Transform _end;
    [Space]
    [SerializeField] private Mesh[] _blockMeshs;
    [Space]
    [SerializeField] private GameObject[] _targetSpawner;
    [SerializeField] private GameObject[] _doors;

    private void Start()
    {
        StartCoroutine(nameof(ToActiveSpawnTarget));

        RandomMesh();
        ToSwapDoor();
    }

    public void ToSwapDoor()
    {
        foreach (GameObject door in _doors)
        {
            if (door.activeSelf)
            {
                door.SetActive(false);
            }
            else
            {
                door.SetActive(true);
            }
        }
            
    }

    private void RandomMesh()
    {
        foreach ( var mesh in GetComponentsInChildren<MeshFilter>())
        {
            if (mesh.sharedMesh == _blockMeshs[0])
            {
                int checkRMD = Random.Range(1, 10);

                if (checkRMD > 5)
                {
                    mesh.sharedMesh = _blockMeshs[Random.Range(0, _blockMeshs.Length)];
                }
            }
        }
    }

    private IEnumerator ToActiveSpawnTarget()
    {
        yield return new WaitForSeconds(0.2f);

        foreach (GameObject target in _targetSpawner) target.SetActive(true);
    }
}
