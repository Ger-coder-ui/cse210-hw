using System;
using System.Collections.Generic;

namespace YouTubeVideoTracker
{
    // Abstraction: Class representing a Comment
    public class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    // Abstraction: Class representing a Video
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating videos
            var video1 = new Video("Exploring AI in 2025", "TechGuru", 720);
            var video2 = new Video("Top 10 Travel Hacks", "NomadLife", 540);
            var video3 = new Video("How to Cook Pasta Perfectly", "ChefDaily", 300);
            var video4 = new Video("Beginner's Guide to Yoga", "FitNow", 600);

            // Adding comments to video1
            video1.AddComment(new Comment("Alice", "This was super informative!"));
            video1.AddComment(new Comment("Bob", "AI is really taking over."));
            video1.AddComment(new Comment("Charlie", "Loved the insights!"));

            // Adding comments to video2
            video2.AddComment(new Comment("Diana", "Just in time for my trip!"));
            video2.AddComment(new Comment("Evan", "Brilliant suggestions."));
            video2.AddComment(new Comment("Fay", "Can you do a packing tips video?"));

            // Adding comments to video3
            video3.AddComment(new Comment("George", "Now I’m hungry."));
            video3.AddComment(new Comment("Hannah", "Tried this recipe and it’s amazing!"));
            video3.AddComment(new Comment("Ian", "Easy to follow, thanks!"));

            // Adding comments to video4
            video4.AddComment(new Comment("Jack", "Perfect for beginners."));
            video4.AddComment(new Comment("Kara", "I feel relaxed already."));
            video4.AddComment(new Comment("Leo", "Subbed!"));

            // List of all videos
            var videos = new List<Video> { video1, video2, video3, video4 };

            // Displaying video details
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");

                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }

                Console.WriteLine(new string('-', 40));
            }
        }
    }
}