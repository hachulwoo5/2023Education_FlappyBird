using UnityEngine;

// ���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
public class Map : MonoBehaviour
{
    public float speed ; // �̵� �ӵ�

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}