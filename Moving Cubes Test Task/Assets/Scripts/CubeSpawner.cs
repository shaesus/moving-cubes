using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeSpawner : MonoBehaviour
{
    public static CubeSpawner instance;

    public float Speed { get; set; } = 1f;
    public float Distance { get; set; } = 3f;

    [SerializeField] private GameObject _cubePrefab;

    private float _spawnCooldown = 1f;

    private bool _isLastCubeDestroyed = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            if (_isLastCubeDestroyed)
            {
                yield return new WaitForSeconds(_spawnCooldown);
                var cube = Instantiate(_cubePrefab, Vector3.zero, Quaternion.identity)
                    .GetComponent<Cube>();
                _isLastCubeDestroyed = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    public void SendLastCubeDestroyed()
    {
        _isLastCubeDestroyed = true;
    }

    public void AssignSpeed(string text)
    {
        if (text != "")
        {
            Speed = float.Parse(text);
        }
    }

    public void AssignDistance(string text)
    {
        if (text != "")
        {
            Distance = float.Parse(text);
        }
    }

    public void AssignTime(string text)
    {
        if (text != "")
        {
            _spawnCooldown = float.Parse(text);
        }
    }
}
