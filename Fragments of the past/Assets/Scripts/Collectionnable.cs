using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectionnableEnum
{
    Chat_perdu,
    Cle_argent,
    Cle_bronze,
    Cle_or,
    Briquet
}

public class Collectionnable : MonoBehaviour
{
    public CollectionnableEnum type;

}
