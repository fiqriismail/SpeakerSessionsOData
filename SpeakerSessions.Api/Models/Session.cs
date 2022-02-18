using System;

namespace SpeakerSessions.Api.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTimeOffset SessionDate { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public Track Track { get; set; }
    }
}
