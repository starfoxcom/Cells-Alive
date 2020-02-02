using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
  public Transform memberPrefab;
  public Transform enemyPrefab;
  public int numberOfMembers;
  public int numberOfEnemies;
  public List<Member> members = new List<Member>();
  public List<Enemy> enemies = new List<Enemy>();
  public float bounds;
  public float spawnRadius;



    // Start is called before the first frame update
  void Start()
  {
    spawn(memberPrefab, numberOfMembers);
    // Comment this line if you dont want enemies
    spawn(enemyPrefab, numberOfEnemies);

    members.AddRange(FindObjectsOfType<Member>());
    // Comment this line if you dont want enemies
    enemies.AddRange(FindObjectsOfType<Enemy>());
  }

  void spawn(Transform _prefab, int _count)
  {
    for(int i = 0; i < _count; i++)
    {
      Instantiate
        (
        _prefab,
        new Vector3(Random.Range(-spawnRadius, spawnRadius),
        Random.Range(-spawnRadius, spawnRadius), 
        0),
        Quaternion.identity
        );
    }
  }

  public List<Member> GetNeighbors(Member _member, float _radius)
  {
    List<Member> neighborsFound = new List<Member>();

    foreach(var otherMembers in members)
    {
      if(otherMembers == _member)
      {
        continue;
      }

      if(Vector3.Distance(_member.position, otherMembers.position) <= _radius)
      {
        neighborsFound.Add(otherMembers);
      }
    }
    return neighborsFound;
  }

  public List<Enemy> GetEnemies(Member _member, float _radius)
  {
    List<Enemy> returnEnemies = new List<Enemy>();

    foreach (var enemy in enemies)
    {
      if (Vector3.Distance(_member.position, enemy.position) <= _radius)
      {
        returnEnemies.Add(enemy);
      }

    }
    return returnEnemies;
  }

//   public void virusDead()
//   {
//     for(int i = 0; i < members.Count; i++)
//     {
//       if (members[i]!=null)
//       {
//         RaycastHit2D Ray = Physics2D.Raycast(members[i].transform.position, members[i].velocity, members[i].velocity.magnitude);
// 
//         if (Ray.collider != null && Ray.collider.gameObject.tag == "BloodCell")
//         {
//           Debug.Log("object collides");
//           Destroy(members[i].gameObject);
//         }
//       }
//       
//     }
//   }
}
