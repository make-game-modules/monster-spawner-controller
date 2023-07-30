using System.Collections;
using UnityEngine;

/// <summary>
/// 2D������������������������ָ����Χ�����ɹ��ͬʱ����������Χһ���İ�ȫ����
/// </summary>
public class MonsterSpawnerController2D : MonoBehaviour
{
    public GameObject role; // ���Ƕ���
    public GameObject monsterPrefab; // ����Ԥ����

    public int maxMonsters = 10; // ���Ĺ�������
    public float spawnRadius = 5f; // �������ɵ�����뾶
    public float spawnInterval = 1f; // ÿ�����ɹ����ʱ����
    public float checkRadius = 1f; // ��鸽���Ƿ�����������İ뾶
    public float safeZoneRadius = 2f; // ��ȫ����İ뾶

    private int currentMonsterCount = 0; // ��ǰ�Ĺ�������

    void Start()
    {
        // ����Ϸ��ʼʱ�����������ɵ�Э��
        StartCoroutine(SpawnMonster());
    }

    /// <summary>
    /// ��ָ�����ʱ�����ɹ��ͬʱ��֤���ɵĹ��ﲻ�������ǵİ�ȫ�����ڡ�
    /// </summary>
    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentMonsterCount < maxMonsters)
            {
                Vector2 spawnPosition = GetRandomPositionAroundRole();

                if (CheckDistanceFromExistingMonsters(spawnPosition))
                {
                    Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
                    currentMonsterCount++;
                }
            }
        }
    }

    /// <summary>
    /// ��������Χ��ָ����Χ������һ�������λ�ã�ͬʱ��֤���λ�ò������ǵİ�ȫ�����ڡ�
    /// </summary>
    /// <returns>�������ɵ����λ�á�</returns>
    Vector2 GetRandomPositionAroundRole()
    {
        Vector2 randomPoint;
        Vector2 spawnPosition;
        do
        {
            randomPoint = Random.insideUnitCircle * spawnRadius;
            spawnPosition = new Vector2(randomPoint.x, randomPoint.y);
            spawnPosition += (Vector2)role.transform.position;
        } while (Vector2.Distance(spawnPosition, role.transform.position) < safeZoneRadius);

        return spawnPosition;
    }

    /// <summary>
    /// ���ָ��λ�ø����Ƿ��Ѿ��������Ĺ��
    /// </summary>
    /// <param name="position">��Ҫ����λ�á�</param>
    /// <returns>��������Ѿ��������Ĺ���򷵻�false�����򷵻�true��</returns>
    bool CheckDistanceFromExistingMonsters(Vector2 position)
    {

        if (checkRadius == 0)
        {
            return true;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, checkRadius);

        if (colliders.Length > 0)
        {
            return false;
        }

        return true;
    }
}
