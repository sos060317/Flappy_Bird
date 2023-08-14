using UnityEngine;

// 파이프 프리팹 관련 스크립트
public class Pipes : MonoBehaviour
{
    public float speed = 5f; // 파이프의 이동 속도
    private float leftEdge;  // 파이프의 최대 이동 거리(파괴되는 지점)

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // 파이프 프리팹의 파괴 지점을 설정
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // 파이프를 이동시켜줌

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject); // 파괴 지점에 도착시 파괴됨
        }
    }
}