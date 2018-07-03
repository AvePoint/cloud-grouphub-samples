namespace Cloud.GroupHub.Samples.Sdk
{
    #region using directives

    using System;
    using GroupHub.Sdk;
    using Xunit;
    using Xunit.Abstractions;

    #endregion using directives

    /// <summary>
    /// GaoApiTest class shows the initial process of the GaoApi sdk, please refer to the
    /// CombineGaoApi test case for detail process. You should replace the datacenter, username and
    /// password to your own to use the API
    /// </summary>
    public class GaoApiTest : IClassFixture<GroupHubApiClassFixtrue>
    {
        public GaoApiTest(ITestOutputHelper testOutput, GroupHubApiClassFixtrue fixtrue)
        {
            this.fixtrue = fixtrue;
            this.output = testOutput;
        }

        private readonly GroupHubApiClassFixtrue fixtrue;
        private readonly ITestOutputHelper output;

        [Trait("Owner", "Baron")]
        [Theory(DisplayName = "GaoApi.Init 001")]
        [InlineData(Region.SoutheastAsia, "baron@baron.sapce", "baron@baron.space")]
        public void Init001(Region region, String username, String password)
        {
            Assert.Equal(1, this.fixtrue.ExecutionCount);
            Assert.True(this.fixtrue.InitStatus);
            this.output.WriteLine("GaoApi class should be initialized once");
        }

        [Trait("Owner", "Baron")]
        [Theory(DisplayName = "GaoApi")]
        [InlineData(Region.SoutheastAsia, "baron@baron.sapce", "baron@baron.space")]
        public void CombineGaoApi(Region region, String username, String password)
        {
        }

        [Trait("Owner", "Baron")]
        [Fact(DisplayName = "GaoApi.Create")]
        public void Create()
        {
        }

        [Trait("Owner", "Baron")]
        [Fact(DisplayName = "GaoApi.Init")]
        public void Init()
        {
            //The code style here is leverage the xUnit test style, you should gurantee that
            //your GaoApi.Init method run once before you can invoke the other GaoApi interface.
            //you can find the Init sample in the GaoApiClassFixture.cs
            Assert.Equal(1, this.fixtrue.ExecutionCount);
            Assert.True(this.fixtrue.InitStatus);
            this.output.WriteLine("GaoApi class should be initialized once");
        }
    }
}