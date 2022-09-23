using CMS.Models;
using Contentful.Core;
using Contentful.Core.Models;
using System.Reflection;

internal class CachingContentfulClient
{
    private ContentfulClient _contentfulClient;

    public CachingContentfulClient(ContentfulClient contentfulClient)
    {
        _contentfulClient = contentfulClient;
    }

    
}