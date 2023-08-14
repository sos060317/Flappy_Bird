using UnityEngine;
using UnityEngine.UI;

// 게임 매니저 스크립트
public class GameManager : MonoBehaviour
{
    public Player player;         // 플레이어
    public Text scoreText;        // 스코어 텍스트
    public GameObject playButton; // 시작 버튼
    public GameObject gameOver;   // 게임 오버 UI
    private int score;            // 게임 스코어 값

    private void Awake()
    {
        Application.targetFrameRate = 60; // 모바일 버전에서 프레임 고정
        
        Pause();
    }

    public void Play()
    {
        score = 0;                         // 게임 스코어를 0으로 초기화
        scoreText.text = score.ToString(); // 게임 스코어 표시
        
        playButton.SetActive(false); // 게임 시작 시 게임 시작 버튼을 없애줌
        gameOver.SetActive(false);   // 게임 시작 시 게임 오버 UI를 없애줌

        Time.timeScale = 1f;   // 게임을 시작하면서 게임의 시간을 흐르게 해줌
        player.enabled = true; // 게임 시작 전에 멈춰두었던 플레이어 스크립트를 켜줌

        Pipes[] pipes = FindObjectsOfType<Pipes>(); // 기존에 생성되었던 파이프를 하나의 배열에 담음

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject); // 배열의 모든 파이프를 삭제해줌
        }
    }

    // 게임 오버 시 게임의 흐름을 멈춰줌
    public void Pause()
    {
        Time.timeScale = 0f;    // 게임의 시간을 멈춰줌
        player.enabled = false; // 플레이어 스크립트를 꺼줌
    }
    
    // 게임 오버 시 버튼과 UI를 켜줌
    public void GameOver()
    {
        gameOver.SetActive(true);   // 게임 오버 UI를 켜줌
        playButton.SetActive(true); // 게임 시작 버튼을 켜줌
        
        Pause();
    }
    
    // 게임 스코어를 증가 시켜줌
    public void IncreaseScore()
    {
        score++;                           // 게임 스코어를 1증가 시켜줌
        scoreText.text = score.ToString(); // 게임 스코어를 적용 해줌
    }
}