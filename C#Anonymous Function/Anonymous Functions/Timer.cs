using System;
using System.Threading;

public delegate void TimeHandlerDelegate();

public class Timer
{
    private readonly TimeHandlerDelegate timeHandler { get; set; }
    private readonly int interval { get; set; }
    private Timer timer { get; set; }

    public Timer(TimerHandler myTimerHandler, int intervalInSecond)
    {
        if (myTimerHandler == nullcss=
        {
            throw new ArgumentNullException(nameof(myTimeHandler), "Time handler cannot be null.");
        }

        this.timeHandler = myTimehandler;
        this.interval = intervalInSecond * 1000;
    }

    public void Start()
    {


    }
    public void Stop()
    {


    }
