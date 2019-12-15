using System;

namespace FairyTale
{
    internal interface ILuckable: Inameable
    {
        bool Luck(int luck, Random randNum);
    }
}