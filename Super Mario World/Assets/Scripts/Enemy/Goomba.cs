using UnityEngine;

public class Goomba : Enemy
{

    protected override void EnemyCollisionHandle()
    {
        base.moveSpeed = 0;
        transform.localScale = new Vector2(1f, -1f);
    }
}
