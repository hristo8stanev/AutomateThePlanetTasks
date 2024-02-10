using System;
using System.Threading;

namespace Anonymous_Method;

public class Timer
{
    public delegate void TimerAction();

    public void Start(int intervalInSeconds, TimerAction action)
    {
        TimerCallback callback = new TimerCallback(state => action()); 

        var timer = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(intervalInSeconds));
    }
}