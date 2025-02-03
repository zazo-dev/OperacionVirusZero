using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3DController : MonoBehaviour
{
    [SerializeField]
    Weapon[] weapons;

    StarterAssetsInputs _input;
    Weapon _currentWeapon;

    int _attackHash;
    int _currentWeaponIndex = 0;
    private bool _attackState;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();   
        _input = GetComponent<StarterAssetsInputs>();
        foreach (var weapon in weapons)
        {
            weapon.SetAnimatorHash(Animator.StringToHash(weapon.GetName()));
        }
        SetWeapon(_currentWeaponIndex);
    }

    private void Update()
    {
        if (_input.switchLeft)
        {
            if (_currentWeaponIndex > 0)
            {
                _currentWeaponIndex--;
                SetWeapon(_currentWeaponIndex);
            }
            _input.switchLeft = false;
        }
        if (_input.switchRight)
        {
            if (_currentWeaponIndex < weapons.Length - 1)
            {
                _currentWeaponIndex++;
                SetWeapon(_currentWeaponIndex);
            }
            _input.switchRight = false;
        }
        if (_attackState != _input.attack)
        {
            _attackState = _input.attack;
            _animator.SetTrigger(_attackHash);
        }
    }

    private void SetWeapon(int current)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.GetContainer().gameObject.SetActive(false);
        }
        _currentWeapon = weapons[current];
        _currentWeapon.GetContainer().gameObject.SetActive(true);
        _attackHash = _currentWeapon.GetAnimatorHash();
    }
}  