using System;
using System.Threading;

public delegate void TimerHandler();

public class Timer
{
    private int minutes;
    private int seconds;
    private TimerHandler myTimerHandler;

    public Timer(int minutes, int seconds, TimerHandler myTimerHandler)
    {
        this.minutes = minutes;
        this.seconds = seconds;
        this.myTimerHandler = myTimerHandler;
    }

    public void Start()
    {
      


    }
}