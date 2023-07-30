using System.Collections;
using UnityEngine;

/// <summary>
/// 2D怪物生成器控制器，用于在指定范围内生成怪物，同时保持主角周围一定的安全区域。
/// </summary>
public class MonsterSpawnerController2D : MonoBehaviour
{
    public GameObject role; // 主角对象
    public GameObject monsterPrefab; // 怪物预制体

    public int maxMonsters = 10; // 最大的怪物数量
    public float spawnRadius = 5f; // 怪物生成的区域半径
    public float spawnInterval = 1f; // 每次生成怪物的时间间隔
    public float checkRadius = 1f; // 检查附近是否有其他怪物的半径
    public float safeZoneRadius = 2f; // 安全区域的半径

    private int currentMonsterCount = 0; // 当前的怪物数量

    void Start()
    {
        // 在游戏开始时启动怪物生成的协程
        StartCoroutine(SpawnMonster());
    }

    /// <summary>
    /// 在指定间隔时间生成怪物，同时保证生成的怪物不会在主角的安全区域内。
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
    /// 在主角周围的指定范围内生成一个随机的位置，同时保证这个位置不在主角的安全区域内。
    /// </summary>
    /// <returns>返回生成的随机位置。</returns>
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
    /// 检查指定位置附近是否已经有其他的怪物。
    /// </summary>
    /// <param name="position">需要检查的位置。</param>
    /// <returns>如果附近已经有其他的怪物，则返回false，否则返回true。</returns>
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
