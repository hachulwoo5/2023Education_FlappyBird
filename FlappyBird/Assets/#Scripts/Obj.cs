using UnityEngine;

// ������ �����ϰ� �ֱ������� ���ġ�ϴ� ��ũ��Ʈ
public class Obj : MonoBehaviour
{
    public GameObject platformPrefab; // ������ ������ ���� ������
    public int count = 3; // ������ ������ ����

    public float timeBetSpawnMin = 1.25f; // ���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetSpawnMax = 2.25f; // ���� ��ġ������ �ð� ���� �ִ�
    private float timeBetSpawn; // ���� ��ġ������ �ð� ����

    public float yMin = -2.2f; // ��ġ�� ��ġ�� �ּ� y��
    public float yMax = 2.2f; // ��ġ�� ��ġ�� �ִ� y��
    private float xPos = 14f; // ��ġ�� ��ġ�� x ��

    private GameObject[] platforms; // �̸� ������ ���ǵ�
    private int currentIndex = 0; // ����� ���� ������ ����

    private Vector2 poolPosition = new Vector2(0, -25); // �ʹݿ� ������ ���ǵ��� ȭ�� �ۿ� ���ܵ� ��ġ
    private float lastSpawnTime; // ������ ��ġ ����
    public bool isDead;


    void Start()
    {
        platforms = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
        // �������� �ʱ�ȭ�ϰ� ����� ���ǵ��� �̸� ����
    }

    void Update()
    {

       

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            // ��ϵ� ������ ��ġ ������ ���� �������� ���� + ��Ÿ���� ���� 1~2�ʸ��� ����
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yMin, yMax);

            // ����� ���� ������ ���� ���ӿ�����Ʈ�� ��Ȱ��ȭ�ϰ� ��� �ٽ� Ȱ��ȭ
            // �̶� ������ �¾���̺� �޼��� ���� 
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            // ����Ű�� ��ġ ����ȭ�ؼ� �ٽ� ��ġ 
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex++;
            if (currentIndex >= count)
            {
                currentIndex = 0;
            }

        }
        // ������ ���ư��� �ֱ������� ������ ��ġ
    }
}