using UnityEngine;

public class CharacterSwordsman : BaseCharacter
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//demo stuff
            PrintInfo();
    }
}
