using UnityEngine;
[CreateAssetMenu(menuName = "Tailsman/SpeedBuff")]
public class SpeedBuff : TailsmanEffects
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Player1>().MoveSpeed += amount;
        target.GetComponent<Player1>().setTimer(30f, () => {
            target.GetComponent<Player1>().MoveSpeed -= amount;
        });
    }
}
