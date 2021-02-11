using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour {


  [SerializeField] private Camera           _camera;
  [SerializeField] private List<GameObject> FlyingObjects;
  [SerializeField] private List<GameObject> Enemies;

  private const int MinY = 15;
  private const int MaxY = 85;

  private void Start() {
    if (!_camera) _camera = Camera.main;
  }

  public void SpawnObject() {
    int i = new Random().Next(0, FlyingObjects.Count);

    Vector2 position = _camera.ViewportToWorldPoint(
      new Vector2(
        1.1f,
        (float) new Random().Next(MinY, MaxY) / 100
      )
    );

    Quaternion rotation = Quaternion.Euler(0, 0, new Random().Next(1, 360));
    Instantiate(FlyingObjects[i], position, rotation);
  }

  public void SpawnEnemy() {
    int i = new Random().Next(0, Enemies.Count);

    Vector2 position = new Vector2(20, 0);

    Quaternion rotation = Quaternion.Euler(0, 0, 0);
    Instantiate(Enemies[i], position, rotation);

  }


}
