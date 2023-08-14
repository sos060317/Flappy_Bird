using UnityEngine;

// 플레이어 관련 스크립트
public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // 프레이어의 스프라이트 렌더러
    public Sprite[] sprites;               // 플레이어의 애니메이션 스프라이트
    private int spriteIndex;               // 플레이어의 애니메이션 스프라이트를 바꾸기 위한 변수
    
    private Vector3 direction;    // 플레이어의 위치 계산 값
    public float gravity = -9.8f; // 플레이어가 떨어지는 중력 값
    public float strength = 5f;   // 플레이어의 점프 값

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러를 가져옴
    }

    private void Start()
    {
        // 인보크리피팅을 통해서 해당 함수를 주기적(지정 값)으로 실행
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position; // 시작 위치 설정
        position.y = 0f;                       // 시작 높이 설정
        transform.position = position;         // 시작 위치를 설정한 시작 위치로 변경
        direction = Vector3.zero;              // 플레이어의 위치 계산 값 초기화
    }

    private void Update()
    {
        // PC버전
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength; // 좌클릭 시 힘만큼 계산
        }

        // 모바일 버전
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // 터치 횟수

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength; // 터치 시 힘만큼 계산
            }
        }

        direction.y += gravity * Time.deltaTime;          // 계산 값의 y값에 속도와 중력값을 곱함
        transform.position += direction * Time.deltaTime; // 계산 값을 위치값에 적용시켜줌
    }

    private void AnimateSprite()
    {
        spriteIndex++; // 인덱스 넘버를 1추가해줌

        if (spriteIndex >= sprites.Length) // 배열의 끝까지 가면
        {
            spriteIndex = 0; // 0으로 초기화 해줌
        }

        spriteRenderer.sprite = sprites[spriteIndex]; // 현재 스프라이트를 인덱스 넘버에 있는 스프라이트로 변경해줌
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle") // 파이프에 닿으면
        {
            FindObjectOfType<GameManager>().GameOver(); // 게임 오버
        }
        else if (other.gameObject.tag == "Scoring") // 스코어와 닿으면
        {
            FindObjectOfType<GameManager>().IncreaseScore(); // 점수가 올라감
        }
    }
}