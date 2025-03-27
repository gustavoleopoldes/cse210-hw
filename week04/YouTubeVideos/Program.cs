//I add the like, dislike and de views of video, 
//and adding more properties on the class video and program 
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to sell Things Online", "ShopMaster", 600);
        for (int i = 0; i < 1500; i++) video1.AddView();
        for (int i = 0; i < 200; i++) video1.AddLike();
        for (int i = 0; i < 15; i++) video1.AddDislike();
        video1.AddComment("John", "Good tutorial!");
        video1.AddComment("Marie", "Very well explained");
        video1.AddComment("Peter", "It helped a lot");
        videos.Add(video1);

        Video video2 = new Video("How to make fondue quickly and easily", "CookingPro", 480);
        for (int i = 0; i < 1600; i++) video2.AddView();  
        for (int i = 0; i < 200; i++) video2.AddLike();    
        for (int i = 0; i < 15; i++) video2.AddDislike(); 
        video2.AddComment("Anna", "I'll try to do it!");
        video2.AddComment("Carl", "It was wonderful");
        video2.AddComment("Julie", "I loved the recipe");
        videos.Add(video2);

        Video video3 = new Video("Guitar for begginers", "MusicMaster", 720);
        for (int i = 0; i < 800; i++) video3.AddView();
        for (int i = 0; i < 150; i++) video3.AddLike();
        for (int i = 0; i < 10; i++) video3.AddDislike();
        video3.AddComment("Luck", "Very good to start");
        video3.AddComment("Paul", "I finally learned");
        video3.AddComment("Michael", "Excelent class");
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("\n====== Video Info ======");
            Console.WriteLine($"Title: {video.GetTitle()}");          
            Console.WriteLine($"Author: {video.GetAuthor()}");       
            Console.WriteLine($"Duration: {video.GetLengthInSeconds()} seconds"); 
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine($"Views: {video.GetViews():N0}");
            Console.WriteLine($"Likes: {video.GetLikes():N0} | Dislikes: {video.GetDislikes():N0}");
            Console.WriteLine($"Approval Rate: {video.GetLikeRatio():F1}%");
    
            Console.WriteLine("\nComments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine("=========================");
        }
    }
}