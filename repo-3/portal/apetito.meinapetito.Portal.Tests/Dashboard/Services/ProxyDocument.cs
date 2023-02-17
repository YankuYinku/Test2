using System;
using System.Collections.Generic;
using prismic;

namespace apetito.meinapetito.Portal.Tests.Dashboard.Services
{
    public class ProxyDocument : Document
    {
        public ProxyDocument(IDictionary<string,Fragment> fragments) : base("","","","",new HashSet<string>(),new List<string>(),
            "",new List<AlternateLanguage>(),fragments,DateTime.Now, DateTime.Now)
        {
            
        }
        
        public ProxyDocument(string id, string uid, string type, string href, ISet<string> tags, IList<string> slugs, string lang, IList<AlternateLanguage> alternateLanguages, IDictionary<string, Fragment> fragments, DateTime? firstPublicationDate, DateTime? lastPublicationDate) : base(id, uid, type, href, tags, slugs, lang, alternateLanguages, fragments, firstPublicationDate, lastPublicationDate)
        {
        }
    }
}