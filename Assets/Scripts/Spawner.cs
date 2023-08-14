using UnityEngine;

// 파이프 스폰
public class Spawner : MonoBehaviour
{
    public GameObject prefab;     // 스폰할 파이프 프리팹
    public float spawnRate = 1f;  // 파이프 프리팹 스폰 간격
    public float minHeight = -1f; // 파이프 프리팹이 스폰될 때, 최소 높이
    public float maxHeight = 1f;  // 파이프 프리팹이 스폰될 때, 최대 높이

    private void OnEnable()
    {
        // 인보크리피팅을 통해서 해당 함수를 주기적(지정 값)으로 실행
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn)); // 캔슬인보크를 통해 해당 함수의 실행을 멈춤
    }

    private void Spawn()
    {
        // 파이프 프리팹을 스폰하고 pipes게임오브젝트에 할당
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        // 파이프 오브젝트를 이동
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}