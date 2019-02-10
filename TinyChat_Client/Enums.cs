namespace TinyChat_Client
{
    //enums for the commands
    public enum type
    {
        UserExit,
        UserExitTimer,
        PCLock,
        PCLockTimer,
        PCRestart,
        PCRestartTimer,
        PCLogOFF,
        PCLogOFFTimer,
        PCShutDown,
        PCShutDownTimer,
        Message,
        ClientLogin,
        ClientLogoff,
        IsNameExists,
        SendClientList,
        test
    }

    public enum LoadMethod
    {
        CallingCode,
        CurrentCode
    }
}