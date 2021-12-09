using UnityEngine;

public struct Player // компонент игрока
{
    public CharacterController characterController;   
    public float playerSpeed, playerSpeedRotation;
    public Animator playerAnimator;
    public Transform playerTransform;

}