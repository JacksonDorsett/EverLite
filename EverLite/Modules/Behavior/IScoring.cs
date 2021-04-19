namespace EverLite.Modules.Behavior
{
    using System;

    public interface IScoring
    {
        event EventHandler OnScoring;

        long GetScore();
    }
}
