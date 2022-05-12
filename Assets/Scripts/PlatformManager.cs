using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

    [SerializeField]
    GameObject platformPrefab;

    [SerializeField]
    float seconds;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            gameObject.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate (platformPrefab, new Vector2 (-3.5f, -2.5f), platformPrefab.transform.rotation);
        Instantiate (platformPrefab, new Vector2 (0f, -2.5f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(3.5f, -2.5f), platformPrefab.transform.rotation);
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds (seconds);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
