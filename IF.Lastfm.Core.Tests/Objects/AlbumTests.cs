﻿using System;
using System.Collections.Generic;
using System.Text;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IF.Lastfm.Core.Tests.Objects
{
    [TestClass]
    public class AlbumTests
    {
        [TestMethod]
        public void AlbumParsesValidJson()
        {
            var jo = ResourceManager.LoadResource(Encoding.UTF8.GetString(TestData.AlbumGetInfo));
            
            var parsed = Album.ParseJToken(jo.SelectToken("album"));

            var expected = new Album()
                {
                    ArtistId = "283786832",
                    ArtistName = "Grimes",
                    ListenerCount = 293542,
                    TotalPlayCount = 10540575,
                    Mbid = "2fd00edb-391a-41ec-8f2f-01e2c202d9eb",
                    Name = "Visions",
                    ReleaseDateUtc = new DateTime(2012, 02, 21, 0, 0, 0),
                    Url = new Uri("http://www.last.fm/music/Grimes/Visions", UriKind.Absolute),
                    TopTags = new List<Tag>
                        {
                            // TODO
                        },
                    Tracks = new List<Track>
                        {
                        }
                };

            Assert.AreEqual(parsed, expected);
        }
    }
}