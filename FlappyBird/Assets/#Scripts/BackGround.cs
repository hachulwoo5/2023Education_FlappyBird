using UnityEngine;

// ���� ������ �̵��� ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ
public class BackGround : MonoBehaviour
{
    private float width; // ����� ���� ����
    BoxCollider2D boxCollider2D;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x;
        // ���� ���̸� �����ϴ� ó��
    }

    private void Update()
    {

        // ���� ��ġ���� -20, �� �� �̻����� �̵��Ѵٸ� ?
        if (transform.position.x <= -width)
        {
            Reposition();
        }

    }

    // ��ġ�� �����ϴ� �޼���
    private void Reposition()
    {
        // 2���� �̹����Ƿ� wid��dml 2�� �̵�
        Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}