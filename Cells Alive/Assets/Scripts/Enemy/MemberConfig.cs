﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberConfig : MonoBehaviour
{
  public float maxFOV = 180f;
  public float maxAcceleration;
  public float maxVelocity;

  // Wonder Variables
  public float wanderJitter;
  public float wanderRadius;
  public float wanderDistance;
  public float wanderPriority;

  // Cohesion Variables
  public float cohesionRadius;
  public float cohesionPriority;

  // Alignment Variables
  public float alignmentRadius;
  public float alignmentPriority;

  // Separation Variables
  public float separationRadius;
  public float separationPriority;

  // Avoidance Variables
  public float avoidanceRadius;
  public float avoidancePriority;
}
