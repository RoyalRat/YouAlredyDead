using UnityEngine;

public class StirringItem : MonoBehaviour
{
    [SerializeField] private int _countToLeave = 1;
    private void Start()
    {
        while (transform.childCount > _countToLeave)
        {
            Transform childTodestroy = transform.GetChild(Random.Range(0, transform.childCount));
            DestroyImmediate(childTodestroy.gameObject);
        }
    }
}