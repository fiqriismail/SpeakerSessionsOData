using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace SpeakerSessions.Api.Models
{
    public static class DataSource
    {
        private static IList<Session> _sessions { get; set; }
        public static IList<Session> GetSessions()
        {
            if (_sessions is not null)
            {
                return _sessions;
            }

            _sessions = new List<Session>();

            Session session = new Session()
            {
                Id = 1,
                Details = "We are looking at OData basics today",
                SessionDate = DateTimeOffset.Now.AddDays(14),
                Speaker = new Speaker()
                {
                    Id = 1,
                    Name = "Fiqri Ismail",
                    Bio = "Public speaker for .NET and other developer technologies",
                    Blog = "https://askfiqri.com",
                    Email = "fiqri.ismail@example.com",
                },
                Title = "Getting started with OData",
                Track = Track.Developer
            };

            _sessions.Add(session);

            session = new Session()
            {
                Id = 2,
                Details = "Azure App Services - Level 100",
                SessionDate = DateTimeOffset.Now.AddDays(14),
                Speaker = new Speaker()
                {
                    Id = 2,
                    Name = "Kasun Rajapakshe",
                    Bio = "Public speaker and DevOps Engineer",
                    Blog = "https://kasunblog.com",
                    Email = "kasunl@example.com",
                },
                Title = "Azure App Services",
                Track = Track.IT
            };

            _sessions.Add(session);

            session = new Session()
            {
                Id = 3,
                Details = "Microsoft Teams for Educators and Schools",
                SessionDate = DateTimeOffset.Now.AddDays(14),
                Speaker = new Speaker()
                {
                    Id = 3,
                    Name = "Hansamali Gamage",
                    Bio = "Public speaker and Teach Lead",
                    Blog = "https://hansamaliblog.com",
                    Email = "hansamali@example.com",
                },
                Title = "Microsoft Teams Getting Started for Educators",
                Track = Track.Educators
            };

            _sessions.Add(session);


            return _sessions;
        }
    }
}
