﻿namespace APBD_CW2;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}