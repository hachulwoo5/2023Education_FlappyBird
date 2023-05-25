using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class Map : MonoBehaviour
{
    public float speed ; // 이동 속도

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}