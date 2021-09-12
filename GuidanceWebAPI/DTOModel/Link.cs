﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuidanceWebAPI.DTOModel
{
    public class Link
    {
        public string Href { get; private set; }
        public string Rel { get; private set; }
        public string Method { get; private set; }

        public Link(string href, string rel, string method)
        {
            this.Href = href;
            this.Rel = rel;
            this.Method = method;
        }
    }
}