using System;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour {


  [SerializeField] private Camera        _camera;
  [SerializeField] private GameObject[ ] FlyingObjects;
  [SerializeField] private GameObject[ ] Enemies;

  private void Start() {
    if (!_camera) _camera = Camera.main;
  }

  public void SpawnObject() {
    const int minY = 15;
    const int maxY = 85;
    
    int i = new Random().Next(0, FlyingObjects.Length);

    Vector2 position = _camera.ViewportToWorldPoint(
      new Vector2(
        1.1f,
        (float) new Random().Next(minY, maxY) / 100
      )
    );

    Quaternion rotation = Quaternion.Euler(0, 0, new Random().Next(1, 360));
    Instantiate(FlyingObjects[i], position, rotation);
  }


}
