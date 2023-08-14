using UnityEngine;

// 맵을 횡 이동 시켜줌
public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer; // 메쉬 랜더러
    public float animationSpeed = 1f;  // 맵이 이동하는 속도

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); // 메쉬 랜더러를 가져옴
    }

    private void Update()
    {
        // 메쉬 랜더러의 머티리얼을 회전(?), 이동(?) 시켜줌
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}