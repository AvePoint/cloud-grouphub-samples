namespace Cloud.GroupHub.Samples.Sdk
{
    #region using directives

    using System;

    #endregion using directives

    /// <summary>
    /// GaoApiClassFixtrue is a global initial class for GaoApi client context initializaion.
    /// </summary>
    public class GroupHubApiClassFixtrue
    {
        public GroupHubApiClassFixtrue()
        {
            this.InitStatus = true;

            this.ExecutionCount++;
        }

        public Boolean InitStatus { get; }
        public Int32 ExecutionCount { get; }
    }
}