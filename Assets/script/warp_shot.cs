using System.Collections;
using UnityEngine;

public class MonstWarpSpawner2D : MonoBehaviour
{
    [Header("ワープホール設定")]
    [SerializeField] private GameObject warpHolePrefab;
    [SerializeField] private int spawnCount = 2;
    [SerializeField] private float spawnInterval = 0.05f;

    [Header("飛び出し距離・時間設定")]
    [SerializeField] private float minDistance = 1.5f;
    [SerializeField] private float maxDistance = 4.0f;
    [SerializeField] private float flyDuration = 0.25f;

    [Header("到着後の展開設定")]
    [SerializeField] private bool expandOnArrive = true;
    [SerializeField] private float expandDuration = 0.15f;
    [SerializeField] private Vector3 targetScale = Vector3.one;

    [Header("起動時に自動実行するか")]
    [SerializeField] private bool spawnOnStart = true;

    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnWarps();
        }
    }

    public void SpawnWarps()
    {
        if (warpHolePrefab == null) return;
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject warp = Instantiate(warpHolePrefab);
            StartCoroutine(LaunchSingleWarp(warp.transform));

            if (spawnInterval > 0f && i < spawnCount - 1)
            {
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    private IEnumerator LaunchSingleWarp(Transform warpTransform)
    {
        Vector3 startPos = transform.position;
        startPos.z = warpTransform.position.z;
        warpTransform.position = startPos;

        if (expandOnArrive)
        {
            warpTransform.localScale = Vector3.zero;
        }

        float angle = Random.Range(0f, Mathf.PI * 2f);
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float distance = Random.Range(minDistance, maxDistance);
        Vector3 targetPos = startPos + new Vector3(dir.x, dir.y, 0f) * distance;

        float elapsed = 0f;
        while (elapsed < flyDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / flyDuration);
            float easeOut = 1f - Mathf.Pow(1f - t, 3f);

            warpTransform.position = Vector3.LerpUnclamped(startPos, targetPos, easeOut);
            yield return null;
        }

        warpTransform.position = targetPos;

        if (expandOnArrive)
        {
            float scaleElapsed = 0f;
            while (scaleElapsed < expandDuration)
            {
                scaleElapsed += Time.deltaTime;
                float st = Mathf.Clamp01(scaleElapsed / expandDuration);
                float popOut = 1f - Mathf.Pow(1f - st, 2f);
                warpTransform.localScale = Vector3.LerpUnclamped(Vector3.zero, targetScale, popOut);
                yield return null;
            }

            warpTransform.localScale = targetScale;
        }
    }
}