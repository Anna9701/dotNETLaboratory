﻿using System;

namespace Laboratorium1.Interfaces
{
    interface IToysSquare
    {
        event EventHandler ToysNumberChanged;

        void AddToy(IToy toy);
        void ChangeSpeed(int change);
        void ChangeDepth(int change);
        void ChangeHeight(int change);
        int ToysNumber { get; }
        void PrintState();
    }
}
