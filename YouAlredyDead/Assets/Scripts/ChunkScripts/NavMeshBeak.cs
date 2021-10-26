using UnityEngine;
using UnityEngine.AI;

public class NavMeshBeak : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
