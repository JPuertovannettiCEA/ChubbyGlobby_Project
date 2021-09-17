using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    public Transform _firePoint;
    public GameObject[] _foodPrefab;

    public float _foodForce = 20f;
    private float _timeBetweenSpawns = 1f;
    private float _timeNext;

    private void Start()
    {
        _timeNext = MainTimer.timer - _timeBetweenSpawns;
    }

    private void Update()
    {
        if (_timeNext >= MainTimer.timer)
        {
            Shoot();
            _timeNext = MainTimer.timer - _timeBetweenSpawns;
        } 

        if (MainTimer.timer <= 30f)
        {
            _timeBetweenSpawns = 0.5f;
        }


    }
    

    void Shoot()
    {
        int i;
        i = Random.Range(0,3);
        GameObject _food = Instantiate(_foodPrefab[i], _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = _food.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _foodForce, ForceMode2D.Impulse);
    }
}
