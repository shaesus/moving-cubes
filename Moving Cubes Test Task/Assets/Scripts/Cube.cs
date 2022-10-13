using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _cubeMaterial;

    private Vector3 _targetVector;

    private void Awake()
    {
        _targetVector = transform.position + Vector3.right * CubeSpawner.instance.Distance;

        _cubeMaterial.SetColor("_Color", new Color(Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
    }

    private void Update()
    {
        if (transform.position == _targetVector)
        {
            Destroy(gameObject);
        }

        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetVector,
            CubeSpawner.instance.Speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        CubeSpawner.instance.SendLastCubeDestroyed();
    }
}
