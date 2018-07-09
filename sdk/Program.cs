namespace Cloud.GroupHub.Sdk.Sample
{
    #region using directives
    using Cloud.GroupHub.Sdk.Model;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Configuration;
    #endregion

    class Program
    {
        /// <summary>
        /// This entrypoint shows that how to create an build-in tag, update an build-in tag, apply the build-in to group,
        /// remove the tag from group and delete the buildin tag. You should replace the wanted value in the app.config
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                var office365TenantId = ConfigurationManager.AppSettings["Office365TenantId"];
                var userName = ConfigurationManager.AppSettings["UserName"];
                Initilize(Region.EastUS, office365TenantId, userName);
                var tagOperations = new TagOperations();
                var groupTagOperations = new GroupTagOperations();
                var tagName = ConfigurationManager.AppSettings["TagName"];
                var tagDescription = ConfigurationManager.AppSettings["TagDescription"];
                var tagModel = tagOperations.SaveBuildInTag(tagName, tagDescription);
                var tagNewName = ConfigurationManager.AppSettings["TagNewName"];
                var tagNewDescription = ConfigurationManager.AppSettings["TagNewDescription"];
                tagOperations.UpdateBuildInTag(tagName, tagNewName, tagNewDescription);
                var groupId = ConfigurationManager.AppSettings["GroupId"];
                groupTagOperations.ApplyBuildInTagToGroup(tagModel.Id, groupId);
                groupTagOperations.UnRegisterBuildInTagFromGroup(tagModel.Id, groupId);
                tagOperations.DeleteBuildInTag(tagModel.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.Read();
        }

        /// <summary>
        /// Init Group Hub api service, when invoking this, it will prompt a logon window, customer need to input the password
        /// </summary>
        /// <param name="region">region of your tenant</param>
        /// <param name="office365TenantId">office 365 tenant id of your tenant</param>
        /// <param name="userName">your user name</param>
        private static void Initilize(Region region, String office365TenantId, String userName)
        {
            var clientId = "d3590ed6-52b3-4102-aeff-aad2292ab01c";
            var redirectUri = "urn:ietf:wg:oauth:2.0:oob";
            var resource = "https://graph.microsoft.com";
            var authority = $"https://login.windows.net/{office365TenantId}";
            var authenticationContext = new AuthenticationContext(authority);
            var userId = new UserIdentifier(userName, UserIdentifierType.OptionalDisplayableId);
            var result = authenticationContext.AcquireToken(resource, clientId, new Uri(redirectUri), PromptBehavior.Always, userId);
            AuthenticationTokenModel model = new AuthenticationTokenModel();
            model.AccessToken = result.AccessToken;
            model.RefreshToken = result.RefreshToken;
            GroupHubApi.Init(region, model);
        }
    }
}
