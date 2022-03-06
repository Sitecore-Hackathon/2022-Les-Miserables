using System;
using System.Collections.Generic;
using System.Text;
using Sitecore.Data;

namespace Mvp.Feature.Blog.Platform
{
    public struct ItemIDs
    {
        public static ID PeopleRootItemID => new ID("{64F31E3A-2040-4E69-B9A7-6830CBE669D2}");
        public static ID PeopleTemplateID => new ID("{AD9C7837-8660-4360-BA2B-7ADDF4163685}");
        public static ID BlogPostFieldID => new ID("{BD4AE4EF-B422-4293-8B08-36A7F86B0F19}");
    }
}
