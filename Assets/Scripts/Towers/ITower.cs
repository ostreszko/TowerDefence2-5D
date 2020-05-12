using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
     void Shoot();
     void Shoot(Transform target,Enemy enemy, Transform shootingPlace);
}
