using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _minLevelCount;
    [SerializeField] private int _maxLevelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatform _finishPlatform;


    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        int _levelCount = Random.Range(_minLevelCount, _maxLevelCount);
        int BeamScaleY = _levelCount * 2;       //calculate the heignt of the beam

        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(2, BeamScaleY, 2);            //spawn beam with required height

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;      //calculate the first position of platform

        SpawnPlatform(_spawnPlatform, ref spawnPosition, Quaternion.identity, transform);       //spawn Spawn Platform

        for (int i = 0; i < _levelCount; i++)                                //spawn required number of Platforms with random quaternion
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)],ref spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, Quaternion.identity, transform);      //spawn Finish Platform
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Quaternion quaternion,Transform parent) {

        Instantiate(platform, spawnPosition, quaternion, parent);
        spawnPosition.y -= 3;
    }
}
