using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member : MonoBehaviour
{
  public Vector3 position;
  public Vector3 velocity;
  public Vector3 acceleration;

  public Level level;
  public MemberConfig conf;

  Vector3 wanderTarget;
  private void Start()
  {
    level = FindObjectOfType<Level>();
    conf = FindObjectOfType<MemberConfig>();

    position = transform.position;
    velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
  }

  private void Update()
  {
    acceleration = Combine();
    acceleration = Vector3.ClampMagnitude(acceleration, conf.maxAcceleration);
    velocity = velocity + acceleration * Time.deltaTime;
    velocity = Vector3.ClampMagnitude(velocity, conf.maxVelocity);
    position = position + velocity * Time.deltaTime;

    WrapAround(ref position, -level.bounds, level.bounds);

    //level.virusDead();

    transform.position = position;
  }

  protected Vector3 Wander()
  {
    float jitter = conf.wanderJitter * Time.deltaTime;
    wanderTarget += new Vector3(0, RandomBinomial() * jitter, 0);
    wanderTarget = wanderTarget.normalized;
    wanderTarget *= conf.wanderRadius;
    Vector3 targetLocalSpace = wanderTarget + new Vector3(conf.wanderDistance, conf.wanderDistance, 0);

    Vector3 targetInworldSpace = transform.TransformPoint(targetLocalSpace);
    targetInworldSpace -= this.position;

    return targetInworldSpace.normalized;
  }

  Vector3 Cohesion()
  {
    Vector3 cohesionVector = new Vector3();
    int countMembers = 0;
    var neighbors = level.GetNeighbors(this, conf.cohesionRadius);
    if(neighbors.Count == 0)
    {
      return cohesionVector;
    }


    foreach(var member in neighbors)
    {
      if(isInFOV(member.position))
      {
        cohesionVector += member.position;
        countMembers++;
      }
    }

    if(countMembers == 0)
    {
      return cohesionVector;
    }

    cohesionVector /= countMembers;
    cohesionVector = cohesionVector - this.position;
    cohesionVector = Vector3.Normalize(cohesionVector);

    return cohesionVector;
  }

  Vector3 Alignment()
  {
    Vector3 alignVector = new Vector3();
    var members = level.GetNeighbors(this, conf.alignmentRadius);

    if(members.Count == 0)
    {
      return alignVector;
    }

    foreach(var member in members)
    {
      if(isInFOV(member.position))
      {
        alignVector += member.velocity;
      }
    }

    return alignVector.normalized;
  }

  Vector3 Separation()
  {
    Vector3 separateVector = new Vector3();
    var members = level.GetNeighbors(this, conf.separationRadius);

    if (members.Count == 0)
    {
      return separateVector;
    }

    foreach (var member in members)
    {
      if (isInFOV(member.position))
      {
        Vector3 movingTowards = this.position - member.position;
        if(movingTowards.magnitude > 0)
        {
          separateVector += movingTowards.normalized / movingTowards.magnitude;
        }
      }
    }

    return separateVector.normalized;
  }

  Vector3 Avoidance()
  {
    Vector3 avoidanceVector = new Vector3();
    var enemyList = level.GetEnemies(this, conf.avoidanceRadius);
    if(enemyList.Count == 0)
    {
      return avoidanceVector;
    }

    foreach(var enemy in enemyList)
    {
      avoidanceVector += RunAway(enemy.position);
    }

    return avoidanceVector.normalized;
  }

  Vector3 RunAway(Vector3 _target)
  {
    Vector3 neededVelocity = (position - _target).normalized * conf.maxVelocity;
    return neededVelocity - velocity;
  }

  virtual protected Vector3 Combine()
  {
    Vector3 finalVec = conf.cohesionPriority * Cohesion() + conf.wanderPriority * Wander()
      + conf.alignmentPriority * Alignment() + conf.separationPriority * Separation()
      + conf.avoidancePriority * Avoidance();
    return finalVec;
  }

  void WrapAround(ref Vector3 _vector, float _min, float _max)
  {
    _vector.x = WrapAroundFloat(_vector.x, _min, _max);
    _vector.y = WrapAroundFloat(_vector.y, _min, _max);
    _vector.z = WrapAroundFloat(_vector.z, _min, _max);
  }

  float WrapAroundFloat(float _value, float _min, float _max)
  {
    if(_value > _max)
    {
      _value = _min;
    }
    else if(_value < _min)
    {
      _value = _max;
    }
    return _value;
  }

  float RandomBinomial()
  {
    return Random.Range(0f, 1f) - Random.Range(0f, 1f);
  }

  bool isInFOV(Vector3 _vec)
  {
    return Vector3.Angle(this.velocity, _vec - this.position) <= conf.maxFOV;
  }

  // This function is for changing the velocity of the agents in a specific moment
  void setVelocity(float _newVelocity)
  {
    velocity *= _newVelocity;
  }

  private void OnTriggerEnter(Collider collision)
  {
    if(collision.gameObject.tag == "BloodCell")
    {
      Debug.Log("Collision");
      Destroy(this.gameObject);
    }
  }
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "BloodCell")
    {
      Debug.Log("Collision");
      this.gameObject.SetActive( false); 
    }
  }
}
