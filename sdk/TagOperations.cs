namespace Cloud.GroupHub.Sdk.Sample
{
    #region using directives

    using Cloud.GroupHub.Sdk.Model;
    using System;
    using System.Linq;

    #endregion

    public class TagOperations
    {
        /// <summary>
        /// Save one build-in tag with specific name and description
        /// </summary>
        /// <param name="name">tag name</param>
        /// <param name="description">tag description</param>
        /// <returns></returns>
        public TagModel SaveBuildInTag(String name, String description)
        {
            var tagService = GroupHubApi.Create<ITagService>();
            TagModel tag = tagService.Save(new TagModel()
            {
                Name = name,
                Description = description,
                Type = 1
            });
            return tag;
        }

        /// <summary>
        /// Update one build-in tag with specific name and description
        /// </summary>
        /// <param name="originalName">original name</param>
        /// <param name="newName">new name</param>
        /// <param name="description">new description</param>
        public void UpdateBuildInTag(String originalName, String newName, String description)
        {
            var tagService = GroupHubApi.Create<ITagService>();
            var allTags = tagService.Get();
            var selectedTag = allTags.ToList().Find(item => item.Name.Equals(originalName) && item.Type == 1);
            if (selectedTag != null)
            {
                selectedTag.Name = newName;
                selectedTag.Description = description;
                tagService.Update(selectedTag.Id, selectedTag);
            }
        }

        /// <summary>
        /// Delete one build-in tag with specific tag id
        /// </summary>
        /// <param name="tagId">tag id</param>
        public void DeleteBuildInTag(String tagId)
        {
            var tagService = GroupHubApi.Create<ITagService>();
            tagService.Delete(tagId);
        }
    }
}
