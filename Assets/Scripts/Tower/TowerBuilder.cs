using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _minLevelCount;
    [SerializeField] private float _maxLevelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startandFinishAdditionalScale = 1f;


    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        float _levelCount = Random.Range(_minLevelCount, _maxLevelCount);
        float BeamScaleY = _levelCount + _startandFinishAdditionalScale + _additionalScale;

        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(2f, BeamScaleY, 2f);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, Quaternion.identity, transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)],ref spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, Quaternion.identity, transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Quaternion quaternion,Transform parent) {

        Instantiate(platform, spawnPosition, quaternion, parent);
        spawnPosition.y -= 2;
    }
}
