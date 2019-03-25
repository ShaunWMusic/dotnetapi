using System;
using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace LibraryApi.Models
{
    public class Review : BelongsToUser
    {
        [Attr("body")] public string Body { get; set; }
        [Attr("created-at")] public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int BookId { get; set; }
        [HasOne("book")] public Book Book { get; set; }
    }
}
