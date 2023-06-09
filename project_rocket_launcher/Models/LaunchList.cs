﻿namespace project_rocket_launcher.Models
{
    /// <summary>
    /// Launch list API schema
    /// </summary>
    public class LaunchList
    {
        public int count { get; set; }
        public string? next { get; set; }
        public string? previous { get; set; }
        public IList<LaunchDetails> results { get; set; } = new List<LaunchDetails>();
    }
}
