using UnityEngine;

public abstract class Field : MonoBehaviour
{
    public static int id;

    public abstract void Activate();

    public Field()
    {
        id = id++;
    }
}
