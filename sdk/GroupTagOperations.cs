namespace Cloud.GroupHub.Sdk.Sample
{
    #region using directives

    using System;

    #endregion
    public class GroupTagOperations
    {
        /// <summary>
        /// Apply build-in tag to group with specific id
        /// </summary>
        /// <param name="tagId">tag id</param>
        /// <param name="groupId">group id</param>
        public void ApplyBuildInTagToGroup(String tagId, String groupId)
        {
            var tagService = GroupHubApi.Create<ITagService>();
            var buildInTag = tagService.Get(tagId);
            var tagGroupService = GroupHubApi.Create<IGroupTagService>();
            tagGroupService.Save(groupId, buildInTag);
        }

        /// <summary>
        /// Remove build-in tag from group with specific id
        /// </summary>
        /// <param name="tagId">tag id</param>
        /// <param name="groupId">group id</param>
        public void UnRegisterBuildInTagFromGroup(String tagId, String groupId)
        {
            var tagGroupService = GroupHubApi.Create<IGroupTagService>();
            tagGroupService.Delete(groupId, tagId);
        }
    }
}
