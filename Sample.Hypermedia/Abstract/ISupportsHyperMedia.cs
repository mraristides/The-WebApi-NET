using System.Collections.Generic;

namespace Sample.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
         List<HyperMediaLink> Links { get; set; }
    }
}